using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vinder.Common.VideoAnalysis
{
    public class Frame
    {
        public int Time { get; set; }

        public IEnumerable<Person> People { get; set; }
    }
}
