using System;
using System.Collections.Generic;
using System.Linq;

namespace Vinder.Common
{
    /// <summary>
    /// Method with time stamp related
    /// </summary>
    public static class TimeStamp
    {
        /// <summary>
        /// it changes original file name with a file name with time stamp
        /// </summary>
        /// <param name="fileName">File name with extension</param>
        /// <returns>Filename with time stamp</returns>
        public static string TimeStampFileName(string fileName)
        {
            return SetTimeStampToFileName(fileName);
        }

        /// <summary>
        /// it changes original files names with files names with time stamp
        /// </summary>
        /// <param name="fileNames"></param>
        /// <returns>List with filename with time stamp</returns>
        public static IEnumerable<string> TimeStampFileNames(IEnumerable<string> fileNames)
        {
            return fileNames.Select(SetTimeStampToFileName);
        }

        /// <summary>
        /// Sets the time stamp
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Filename with time stamp</returns>
        private static string SetTimeStampToFileName(string fileName)
        {
            return fileName.Replace(".", $"-{DateTime.UtcNow.ToString("yyyyMMddHHmmssffff")}.");
        }
    }
}