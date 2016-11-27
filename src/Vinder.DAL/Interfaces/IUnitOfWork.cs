using System;

namespace Vinder.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        IEmotionRepository Emotions { get; }

        IMatchRepository Match { get; }

        void SaveChanges();
    }
}