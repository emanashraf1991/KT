using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT.Application.Users.Commands
{
    public class CreateUserCommand
    {
        public long ICnumber { get; set; }
        public string CustomerName { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
    }
}
