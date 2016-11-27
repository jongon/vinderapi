using System;

namespace Vinder.DAL.Domain
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; }

        public DateTime BirthDate { get; set; }

        public Emotion Emotion { get; set; }
    }
}