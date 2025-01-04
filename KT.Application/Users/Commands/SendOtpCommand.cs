using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT.Application.Users.Commands
{
    public class SendOtpCommand
    {
        public string MobileNumber { get; set; }
        public string Email { get; set; }
    }
}
