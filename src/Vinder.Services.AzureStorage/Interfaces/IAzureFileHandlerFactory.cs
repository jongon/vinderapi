namespace Vinder.Services.AzureStorage.Interfaces
{
    public interface IAzureFileHandlerFactory
    {
        /// <summary>
        /// Factory Method that creates an Azure File Handler Service
        /// </summary>
        /// <param name="storageConnectionstring">Storage Connection string</param>
        /// <param name="containerName">Container name</param>
        IFileHandler GetService(string storageConnectionstring, string containerName);
    }
}