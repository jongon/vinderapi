using System.Collections.Generic;

namespace Vinder.Common
{
    public class CommonModel
    {
        /// <summary>
        /// If Record or some operation with is valid
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Error o issues messages
        /// </summary>
        public IEnumerable<Message> Messages { get; set; }
    }
}