using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vinder.Common;
using Vinder.Services.AzureStorage.Interfaces;

namespace Vinder.Services.AzureStorage
{
    /// <summary>
    /// Azure file Service to Upload, remove files on Storage blob
    /// </summary>
    public class AzureFileHandlerService : IFileHandler
    {
        /// <summary>
        /// Storage Connection String
        /// </summary>
        public string StorageConnectionString { get; set; }

        /// <summary>
        /// Container Name
        /// </summary>
        public string ContainerName { get; set; }

        /// <summary>
        /// AzureFileHandlerService Constructor
        /// </summary>
        /// <param name="storageConnectionString">Azure storage connection string</param>
        /// <param name="containerName">Container name</param>
        public AzureFileHandlerService(string storageConnectionString, string containerName)
        {
            StorageConnectionString = storageConnectionString;
            ContainerName = containerName;
        }

        /// <summary>
        /// Upload many files to Azure Storage blob
        /// </summary>
        /// <param name="files">Collection of files</param>
        /// <returns>Image uris in string</returns>
        public async Task<IEnumerable<string>> SaveFilesAsync(IEnumerable<CommonFile> files)
        {
            var container = await GetContainerAsync(StorageConnectionString, ContainerName);

            var uris = new List<string>();

            foreach (var file in files)
            {
                var blockBlob = container.GetBlockBlobReference(TimeStamp.TimeStampFileName(file.Name));

                // Create or overwrite the blob with the contents of a local file
                using (var fileStream = file.File.ToStream())
                {
                    await blockBlob.UploadFromStreamAsync(fileStream);
                }

                uris.Add(blockBlob.Uri.AbsoluteUri);
            }

            return uris;
        }

        /// <summary>
        /// Upload file to Azure Storage blob
        /// </summary>
        /// <param name="file">File to upload</param>
        /// <returns>Image uris in string</returns>
        public async Task<string> SaveFileAsync(CommonFile file)
        {
            var container = await GetContainerAsync(StorageConnectionString, ContainerName);

            var blockBlob = container.GetBlockBlobReference(TimeStamp.TimeStampFileName(file.Name));

            // Create or overwrite the blob with the contents of a local file
            using (var fileStream = file.File.ToStream())
            {
                await blockBlob.UploadFromStreamAsync(fileStream);
            }

            return blockBlob.Uri.AbsoluteUri;
        }

        /// <summary>
        /// Remove many files from Azure Storage blob
        /// </summary>
        /// <param name="fileNames">File names to delete</param>
        public async Task RemoveFilesAsync(IEnumerable<string> fileNames)
        {
            var container = await GetContainerAsync(StorageConnectionString, ContainerName);

            foreach (var fileName in fileNames)
            {
                // Get a reference to a blob
                var blockBlob = container.GetBlockBlobReference(fileName);

                // Delete the blob if it is existing
                await blockBlob.DeleteIfExistsAsync();
            }
        }

        /// <summary>
        /// Remove a file from Azure Storage blob
        /// </summary>
        /// <param name="fileName">File name to delete</param>
        /// <returns>true if succeeded otherwise false</returns>
        public async Task RemoveFileAsync(string fileName)
        {
            var container = await GetContainerAsync(StorageConnectionString, ContainerName);

            // Get a reference to a blob
            var blockBlob = container.GetBlockBlobReference(fileName);

            // Delete the blob if it is existing
            await blockBlob.DeleteIfExistsAsync();
        }

        /// <summary>
        /// Get Azure container to upload files
        /// </summary>
        /// <param name="storageConnectionString">Connection String</param>
        /// <param name="blobContainerName">Container name</param>
        /// <returns>Clod container</returns>
        private static async Task<CloudBlobContainer> GetContainerAsync(string storageConnectionString, string blobContainerName)
        {
            //Sets Connection String
            var storageAccount = CloudStorageAccount.Parse(storageConnectionString);

            // Create a blob client.
            var blobClient = storageAccount.CreateCloudBlobClient();

            // Get a reference to a container
            var container = blobClient.GetContainerReference(blobContainerName);

            // If container doesn’t exist, create it.
            await container.CreateIfNotExistsAsync(BlobContainerPublicAccessType.Blob, null, null);

            return container;
        }
    }
}