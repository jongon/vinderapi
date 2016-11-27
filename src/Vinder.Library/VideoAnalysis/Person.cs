namespace Vinders.Library.VideoAnalysis
{
    public class Person
    {
        public string PersonId { get; set; }

        public Demographics Demographics { get; set; }

        public Appearance Appearance { get; set; }

        public Emotions Emotions { get; set; }

        public Tracking Tracking { get; set; }

        public Pose Pose { get; set; }

        public Face Face { get; set; }

        public decimal Distance { get; set; }
    }
}