using domain.Core.Interfaces.Repositories;
using domain.Core.Interfaces.Services;
using domain.Domain.Entities;

namespace domain.Services
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