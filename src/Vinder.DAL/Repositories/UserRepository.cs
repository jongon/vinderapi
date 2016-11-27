using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vinder.DAL.Interfaces;

namespace Vinder.DAL.Repositories
{
    public class UserRepository : Repository<UserRepository>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
    }
}
