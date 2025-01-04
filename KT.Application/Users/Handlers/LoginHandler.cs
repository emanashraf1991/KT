using KT.Application.IRepository;
using KT.Application.Result;
using KT.Application.Users.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT.Application.Users.Handlers
{
     
    public class LoginHandler 
    {
        private readonly IUserRepository _userRepository;
       
        public LoginHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository; 
        }

        public async Task<LoginResult> Handle(LoginCommand command)
        {
            // Find the user by email or mobile
            var user = await _userRepository.GetByIcNumberAsync(command.ICnumber);
            if (user == null )
            {
                return null; // Invalid credentials
            }

            // Generate JWT token
            var token = "jwttoken";

            return new LoginResult { Token = token };
        }
    }

}
