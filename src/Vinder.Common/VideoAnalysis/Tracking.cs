using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vinder.Common.VideoAnalysis
{
    public class Tracking
    {
        public int Glances { get; set; }

        public int Dwell { get; set; }

        public int Attention { get; set; }

        public string Blink { get; set; }
    }
}
