namespace VinderApi.Configuration
{
    public class AzureStorageSettings
    {
        /// <summary>
        /// Connection string (Account name and Account key)
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Misc Content container
        /// </summary>
        public string VideoContainer { get; set; }
    }
}