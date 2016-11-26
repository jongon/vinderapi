using System.Collections;
using System.Collections.Generic;

namespace Vinder.Common.VideoAnalysis
{
    public class VideoAnalysis
    {
        public string Id { get; set; }

        public MediaInfo MediaInfo { get; set; }

        public IEnumerable<Impression> Impressions { get; set; }
    }
}
