using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT.Application.Users.Commands
{
    public class SetPinCommand
    {
        public int UserId { get; set; }
        public string Pin { get; set; }
    }
}
