using Vinder.Services.AzureStorage.Interfaces;

namespace Vinder.Services.AzureStorage.Factories
{
    public class AzureFileHandlerFactory : IAzureFileHandlerFactory
    {
        /// <summary>
        /// Factory Method that creates an Azure File Handler Service
        /// </summary>
        /// <param name="storageConnectionString">Storage Connection string</param>
        /// <param name="containerName">Container name</param>
        /// <returns></returns>
        public IFileHandler GetService(string storageConnectionString, string containerName)
        {
            return new AzureFileHandlerService(storageConnectionString, containerName);
        }
    }
}