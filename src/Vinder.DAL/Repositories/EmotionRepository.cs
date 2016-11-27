using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vinder.DAL.Interfaces;

namespace Vinder.DAL.Repositories
{
    public class EmotionRepository : Repository<EmotionRepository>, IEmotionRepository
    {
        public EmotionRepository(DbContext context) : base(context)
        {
        }
    }
}
