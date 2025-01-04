using KT.Application.IRepository;
using KT.Application.Users.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT.Application.Users.Handlers
{
     
    public class VerifyOtpHandler
    {
        private readonly IOtpRepository _otpRepository;
        private readonly IUserRepository _userRepository;

        public VerifyOtpHandler(IOtpRepository otpRepository, IUserRepository userRepository)
        {
            _otpRepository = otpRepository;
            _userRepository = userRepository;
        }

        public async Task Handle(VerifyOtpCommand command)
        {
            // Retrieve OTP from the repository
            var otp = await _otpRepository.GetOtpByEmailOrMobileAsync(command.EmailOrMobile);
            if (otp == null)
            {
                throw new Exception("OTP not found.");
            }

            // Validate OTP
            if (otp.Code != command.Code || otp.ExpiryTime < DateTime.UtcNow)
            {
                throw new Exception("Invalid or expired OTP.");
            }

            // Mark OTP as verified
            otp.IsVerified = true;
            await _otpRepository.UpdateAsync(otp);

            // Update user's verification status
            var user = await _userRepository.GetByEmailOrMobileAsync(command.EmailOrMobile);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            if (command.EmailOrMobile.Contains("@"))
            {
                user.IsEmailVerified = true;
            }
            else
            {
                user.IsMobileVerified = true;
            }

            await _userRepository.UpdateAsync(user);
        }
    }
}

