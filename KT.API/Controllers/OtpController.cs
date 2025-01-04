using KT.Application.IService;
using KT.Application.Users.Commands;
using KT.Application.Users.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace KT.API.Controllers
{
    public class OtpController : Controller
    {
        private readonly SendOtpHandler _sendOtpHandler;
        private readonly VerifyOtpHandler _verifyOtpHandler;
        public OtpController(  SendOtpHandler sendOtpHandler ,VerifyOtpHandler verifyOtpHandler )
        { 
            _sendOtpHandler = sendOtpHandler;
            _verifyOtpHandler = verifyOtpHandler;
           
        }

        [HttpPost("SendOtp")]
        public async Task<IActionResult> SendOtp([FromBody] SendOtpCommand command)
        {
            await _sendOtpHandler.Handle(command);
            return Ok("OTP verified successfully.");
        }
        [HttpPost("VerifyOtp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpCommand command)
        {
            await _verifyOtpHandler.Handle(command);
            return Ok("OTP verified successfully.");
        }
    }
}
