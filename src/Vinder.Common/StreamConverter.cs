using System.IO;

namespace Vinder.Common
{
    public static class StreamConverter
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] ToBytes(this Stream stream)
        {
            using (var fileStream = stream)
            using (var ms = new MemoryStream())
            {
                fileStream.CopyTo(ms);
                var fileBytes = ms.ToArray();
                return fileBytes;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static Stream ToStream(this byte[] stream)
        {
            return new MemoryStream(stream);
        }
    }
}