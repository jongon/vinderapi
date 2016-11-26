using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vinder.Common.VideoAnalysis
{
    public class AverageEmotion
    {
        public decimal Anger { get; set; }

        public decimal Disgust { get; set; }

        public decimal Fear { get; set; }

        public decimal Joy { get; set; }

        public decimal Sadness { get; set; }

        public decimal Surprise { get; set; }
    }
}
