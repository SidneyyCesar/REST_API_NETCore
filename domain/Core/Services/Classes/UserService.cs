using domain.Core.Interfaces.Repositories;
using domain.Core.Interfaces.Services;
using domain.Domain.Core;

namespace domain.Services.Classes
{
    public class UserService: ServiceBase<Users>, IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository): base(userRepository) 
        {
            this.userRepository = userRepository;
        }
    }
}