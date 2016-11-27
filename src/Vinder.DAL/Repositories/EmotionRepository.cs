﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vinder.DAL.Domain;
using Vinder.DAL.Interfaces;

namespace Vinder.DAL.Repositories
{
    public class EmotionRepository : Repository<Emotion>, IEmotionRepository
    {
        public EmotionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
