using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vinder.DAL.Domain;
using Vinder.DAL.Interfaces;

namespace Vinder.DAL.Repositories
{
    public class MatchRepository : Repository<Match>, IMatchRepository
    {
        public MatchRepository(DbContext context) : base(context)
        {
        }

        //public IEnumerable<User> GetMatch(Guid userId)
        //{
        //    //return Context.
        //}
    }
}
