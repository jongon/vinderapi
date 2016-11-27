namespace Vinder.Common
{
    public class CommonFile : CommonModel
    {
        /// <summary>
        /// File in bytes
        /// </summary>
        public byte[] File { get; set; }

        /// <summary>
        /// Name of the file
        /// </summary>
        public string Name { get; set; }
    }
}