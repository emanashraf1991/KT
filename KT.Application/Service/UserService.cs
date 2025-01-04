using KT.Application.IRepository;
using KT.Application.IService;
using KT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT.Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }
        public List<User> GetAllUsers()
        {
            var users = userRepository.GetAllAsync();

            return users.Result.ToList();
        }
    }
}
