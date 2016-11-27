using System.Collections.Generic;

namespace Vinders.Library.VideoAnalysis
{
    public class VideoAnalysis
    {
        public string Id { get; set; }

        public MediaInfo MediaInfo { get; set; }

        public IEnumerable<Impression> Impressions { get; set; }
    }
}
