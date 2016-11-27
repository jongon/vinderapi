namespace Vinders.Library.VideoAnalysis
{
    public class Impression
    {
        public int PersonId { get; set; }

        public Tracking Tracking { get; set; }

        public Demographics Demographics { get; set; }

        public Appearance Appearance { get; set; }

        public AverageEmotion AverageEmotion { get; set; }

        public EmotionScore EmotionScore { get; set; }
    }
}