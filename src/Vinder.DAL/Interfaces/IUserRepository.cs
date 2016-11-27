using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinder.DAL.Domain;
using Vinder.DAL.Repositories;

namespace Vinder.DAL.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
