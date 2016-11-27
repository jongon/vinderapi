using System.Collections.Generic;

namespace Vinders.Library.VideoAnalysis
{
    public class Frame
    {
        public int Time { get; set; }

        public IEnumerable<Person> People { get; set; }
    }
}