using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vinder.DAL.Interfaces;

namespace Vinder.DAL.Repositories
{
    public class MatchRepository : Repository<MatchRepository>, IMatchRepository
    {
        public MatchRepository(DbContext context) : base(context)
        {
        }
    }
}
