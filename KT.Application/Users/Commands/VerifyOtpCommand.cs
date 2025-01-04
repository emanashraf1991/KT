using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT.Application.Users.Commands
{
    public class VerifyOtpCommand
    {
        public string Code { get; set; }
        public string EmailOrMobile { get; set; }
    } 
}
