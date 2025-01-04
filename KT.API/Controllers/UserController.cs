using KT.Application.IService;
using KT.Application.Users.Commands;
using KT.Application.Users.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KT.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly CreateUserHandler _createUserHandler;
         private readonly SetPinHandler _setPinHandler;
        private readonly LoginHandler _loginHandler;

        public UserController(IUserService userService, CreateUserHandler createUserHandler,
            SetPinHandler setPinHandler, LoginHandler loginHandler)
        {
            _createUserHandler = createUserHandler;
            _setPinHandler = setPinHandler;
            _userService = userService;
            _loginHandler = loginHandler;
        }


        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            await _createUserHandler.Handle(command);
            return Ok("User created successfully. ");
        }

       

        [HttpPost("SetPin")]
        public async Task<IActionResult> SetPin([FromBody] SetPinCommand command)
        {
            await _setPinHandler.Handle(command);
            return Ok("PIN set successfully.");
        }

        [HttpPost("Login")]       
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            if (command == null || string.IsNullOrEmpty(command.ICnumber.ToString()))
            {
                return BadRequest("icnumber is required.");
            }

            var result = await _loginHandler.Handle(command);

            if (result == null)
            {
                return Unauthorized("Invalid credentials.");
            }

            return Ok(new { Token = result.Token });
        }
        [HttpPost("ShowDashboard")]
        //[Authorize] //should be 
        public async Task<IActionResult> ShowDashboard([FromBody] string token)
        {
            //verify token
            return Ok("Welcome");
        }
    }
}
