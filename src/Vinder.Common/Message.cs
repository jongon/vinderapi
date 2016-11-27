namespace Vinder.Common
{
    public class Message
    {
        /// <summary>
        /// Message of Issue or Error
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Field validated
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// Error code or Warning code
        /// </summary>
        public string Code { get; set; }
    }
}