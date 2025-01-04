using KT.Application.IRepository;
using KT.Application.Service;
using KT.Application.Users.Commands;
using KT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT.Application.Users.Handlers
{
    public class CreateUserHandler
    {
        private readonly IUserRepository _repository;
        private readonly OtpService _otpService;

        public CreateUserHandler(IUserRepository repository, OtpService otpService)
        {
            _repository = repository;
            _otpService = otpService;
        }

        public async Task Handle(CreateUserCommand command)
        {
            var user = new User
            {
                ICnumber = command.ICnumber,
                CustomerName = command.CustomerName,
                MobileNumber = command.MobileNumber,
                EmailAddress=command.EmailAddress,
                CreatedAt = DateTime.UtcNow,
                IsEmailVerified=false,
                IsMobileVerified=false,
                Pin=""//set empty for now then update later in specific step
            };

            await _repository.AddAsync(user);

        }
    }
}
