using System;

namespace Vinder.DAL.Domain
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public string AgeGroup { get; set; }

        public Emotion Emotion { get; set; }

        public string BestEmotion { get; set; }

        public string VideoUrl { get; set; }

        public string ThumbnailUrl { get; set; }
    }
}