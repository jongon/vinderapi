using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinder.DAL.Domain;
using VinderApi.ViewModels;
using Vinders.Library.VideoAnalysis;

namespace VinderApi.Factories.Interfaces
{
    public interface IUserFactory
    {
        User Get(CreateUserViewModel user);

        User GetWithEmotions(User user, VideoMedia videoMedia);
    }
}
