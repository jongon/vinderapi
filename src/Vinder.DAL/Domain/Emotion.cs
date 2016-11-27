using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vinder.DAL.Domain
{
    public class Emotion
    {
        [ForeignKey("User")]
        public Guid Id { get; set; }

        public decimal Anger { get; set; }

        public decimal Disgust { get; set; }

        public decimal Fear { get; set; }

        public decimal Joy { get; set; }

        public decimal Sadness { get; set; }

        public decimal Surprise { get; set; }

        public User User { get; set; }
    }
}