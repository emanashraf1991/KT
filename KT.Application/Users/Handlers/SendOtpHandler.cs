using KT.Application.IRepository;
using KT.Application.Service;
using KT.Application.Users.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT.Application.Users.Handlers
{
    public class SendOtpHandler
    {
        private readonly OtpService _otpService;
 
        public SendOtpHandler(OtpService otpService )
        {
            _otpService = otpService;
        }

        public async Task Handle(SendOtpCommand command)
        {
            if (command.Email.Contains("@"))
            {
                await _otpService.SendOtpAsync(command.Email);
            }
            else
            {
                await _otpService.SendOtpAsync(command.MobileNumber);
            }
        }
    }
}
