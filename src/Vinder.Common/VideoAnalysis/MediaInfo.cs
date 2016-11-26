using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vinder.Common.VideoAnalysis
{
    public class MediaInfo
    {
        public int Length { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string Type { get; set; }

        public string FileName { get; set; }

        public string MimeType { get; set; }
    }
}
