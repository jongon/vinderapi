using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vinder.DAL
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Emotion Emotion { get; set; }
    }
}
