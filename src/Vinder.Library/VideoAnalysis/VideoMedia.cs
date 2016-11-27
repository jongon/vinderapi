using System.Collections.Generic;

namespace Vinders.Library.VideoAnalysis
{
    public class VideoMedia
    {
        public string Id { get; set; }

        public MediaInfo MediaInfo { get; set; }

        public IEnumerable<Frame> Frames { get; set; }

        public int StatusCode { get; set; }

        public string StatusMessage { get; set; }

        public int Length { get; set; }
    }
}
