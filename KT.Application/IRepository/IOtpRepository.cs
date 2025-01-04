using KT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT.Application.IRepository
{
    public interface IOtpRepository
    {
        Task<Otp?> GetOtpByEmailOrMobileAsync(string emailOrMobile);
        Task AddAsync(Otp otp);
        Task UpdateAsync(Otp otp);
    }
}
