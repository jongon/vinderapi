using System;
using Vinder.DAL.Configuration;
using Vinder.DAL.Interfaces;
using Vinder.DAL.Repositories;

namespace Vinder.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Users = new UserRepository(context);
            Emotions = new EmotionRepository(context);
            Match = new MatchRepository(context);
        }

        public IEmotionRepository Emotions { get; }

        public IMatchRepository Match { get; }

        public IUserRepository Users { get; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}