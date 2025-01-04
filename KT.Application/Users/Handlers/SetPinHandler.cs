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
    public class SetPinHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly PinService _pinService;

        public SetPinHandler(IUserRepository userRepository, PinService pinService)
        {
            _userRepository = userRepository;
            _pinService = pinService;
        }

        public async Task Handle(SetPinCommand command)
        {
            // Retrieve user
            var user = await _userRepository.GetByIdAsync(command.UserId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            // Validate PIN length
            if (command.Pin.Length != 6 || !int.TryParse(command.Pin, out _))
            {
                throw new Exception("PIN must be a 6-digit numeric value.");
            }

            // Hash the PIN
            var hashedPin = _pinService.HashPin(command.Pin);

            // Update user with the hashed PIN
            user.Pin = hashedPin;
            await _userRepository.UpdateAsync(user);
        }
    }
}
