using System;
using System.Collections.Generic;
using System.Linq;

namespace Vinders.Library.Emotions
{
    public class EmotionRater
    {
        private readonly VideoAnalysis.Emotions _emotions;

        public EmotionRater(VideoAnalysis.Emotions emotions)
        {
            _emotions = emotions;
        }

        public string GetBestEmotion()
        {
            var emotionDictionary = new Dictionary<string, decimal>
            {
                { "Joy", _emotions.Joy },
                { "Disgust", _emotions.Disgust },
                { "Anger", _emotions.Anger },
                { "Sadness", _emotions.Sadness },
                { "Surprise", _emotions.Surprise },
                { "Fear", _emotions.Fear }
            };

            return emotionDictionary
                .OrderByDescending(x => x.Value)
                .Select(x => x.Key)
                .First();
        }
    }
}
