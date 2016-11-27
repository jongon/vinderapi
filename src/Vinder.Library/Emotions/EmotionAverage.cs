using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinders.Library.VideoAnalysis;

namespace Vinders.Library.Emotions
{
    public static class EmotionAverage
    {
        public static VideoAnalysis.Emotions GetAverage(IEnumerable<Frame> frames)
        {
            var emotions = frames
                .Select(x => x.People.First())
                .Select(x => x.Emotions)
                .ToList();

            var emotionAverage = new VideoAnalysis.Emotions
            {
                Joy = emotions.Average(x => x.Joy),
                Surprise = emotions.Average(x => x.Surprise),
                Anger = emotions.Average(x => x.Anger),
                Disgust = emotions.Average(x => x.Disgust),
                Sadness = emotions.Average(x => x.Sadness),
                Fear = emotions.Average(x => x.Fear)
            };

            return emotionAverage;
        }
    }
}
