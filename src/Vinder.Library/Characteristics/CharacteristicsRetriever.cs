using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinders.Library.VideoAnalysis;

namespace Vinders.Library.Characteristics
{
    public static class CharacteristicsRetriever
    {
        public static string GetGender(IEnumerable<Frame> frames)
        {
            return frames.First().People.First().Demographics.Gender;
        }

        public static string GetAgeGroup(IEnumerable<Frame> frames)
        {
            return frames.First().People.First().Demographics.AgeGroup;
        }
    }
}
