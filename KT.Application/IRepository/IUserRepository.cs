using KT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT.Application.IRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByIcNumberAsync(long icnumber);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id); 
        Task<User?> GetByEmailOrMobileAsync(string emailOrMobile); 
    }
}
