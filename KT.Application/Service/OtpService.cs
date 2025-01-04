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
    public class OtpService
    {
        private readonly IOtpRepository _otpRepository;
        private readonly IEmailService _emailService;
        private readonly ISmsService _smsService;

        public OtpService(IOtpRepository otpRepository,IEmailService emailService, ISmsService smsService)
        {
            _otpRepository = otpRepository;
            _emailService = emailService;
            _smsService = smsService;
        }
 
       
        public async Task SendOtpAsync(string emailOrMobile)
        {
            // Generate a random OTP
            var otpCode = new Random().Next(1000, 9999).ToString();

            // Create OTP entity
            var otp = new Otp
            {
                Code = otpCode,
                EmailOrMobile = emailOrMobile,
                ExpiryTime = DateTime.UtcNow.AddMinutes(5), // OTP expires in 5 minutes
                IsVerified = false
            };

            // Save OTP to database
            await _otpRepository.AddAsync(otp);

            // Send OTP via email or SMS
            if (emailOrMobile.Contains("@"))
            {
                await _emailService.SendEmailAsync(emailOrMobile, "Your OTP Code", $"Your OTP code is: {otpCode}");
            }
            else
            {
                await _smsService.SendSmsAsync(emailOrMobile, $"Your OTP code is: {otpCode}");
            }
        }
        }
}
