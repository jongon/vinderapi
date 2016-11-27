using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vinder.DAL.Domain;
using Vinder.DAL.Interfaces;
using Vinder.DAL.Configuration;

namespace Vinder.DAL.Repositories
{
    public class MatchRepository : Repository<Match>, IMatchRepository
    {
        public MatchRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IEnumerable<User> GetMatch(Guid userId)
        {
            var currentUser = Context.Users.First(x => x.Id == userId);

            return Context.Users.Where(x =>
                x.BestEmotion == currentUser.BestEmotion &&
                x.AgeGroup == currentUser.AgeGroup &&
                x.Gender != currentUser.Gender);
        }
    }
}
