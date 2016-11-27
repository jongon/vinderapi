using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinder.DAL.Domain;
using VinderApi.Factories.Interfaces;
using VinderApi.ViewModels;
using Vinders.Library.Characteristics;
using Vinders.Library.Emotions;
using Vinders.Library.VideoAnalysis;

namespace VinderApi.Factories
{
    public class UserFactory : IUserFactory
    {
        private EmotionRater _emotionRater;

        public User Get(CreateUserViewModel user)
        {
            return new User
            {
                Name = user.Name,
                Id = Guid.NewGuid(),
                ThumbnailUrl = user.ThumbnailUrl,
                VideoUrl = user.AzureVideoUrl
            };
        }

        public User GetWithEmotions(User user, VideoMedia videoMedia)
        {
            var emotionAverage = EmotionAverage.GetAverage(videoMedia.Frames);
            user.Emotion = new Emotion
            {
                Anger = emotionAverage.Anger,
                Disgust = emotionAverage.Disgust,
                Fear = emotionAverage.Fear,
                Sadness = emotionAverage.Sadness,
                Joy = emotionAverage.Joy,
                Surprise = emotionAverage.Surprise
            };
            _emotionRater = new EmotionRater(emotionAverage);
            user.BestEmotion = _emotionRater.GetBestEmotion();
            user.Gender = CharacteristicsRetriever.GetGender(videoMedia.Frames);
            user.AgeGroup = CharacteristicsRetriever.GetAgeGroup(videoMedia.Frames);

            return user;
        }
    }
}
