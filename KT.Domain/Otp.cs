using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT.Domain
{
    public class Otp
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string EmailOrMobile { get; set; }
        public DateTime ExpiryTime { get; set; }
        public bool IsVerified { get; set; }
    }

}
