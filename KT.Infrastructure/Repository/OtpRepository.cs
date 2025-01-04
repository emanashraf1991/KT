using KT.Application.IRepository;
using KT.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT.Infrastructure.Repository
{
    public class OtpRepository : IOtpRepository
    {
        private readonly UserDbContext _context;

        public OtpRepository(UserDbContext context)
        {
            _context = context;
        }
       
        public async Task<Otp> GetOtpByEmailOrMobileAsync(string emailOrMobile)
        {
            return await _context.Otps
                .FirstOrDefaultAsync(o => o.EmailOrMobile == emailOrMobile && !o.IsVerified);
        }

        public async Task AddAsync(Otp otp)
        {
            await _context.Otps.AddAsync(otp);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Otp otp)
        {
            _context.Otps.Update(otp);
            await _context.SaveChangesAsync();
        }
    }
}
