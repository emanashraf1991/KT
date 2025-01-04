using KT.Application.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT.Infrastructure.Services
{
    public class SmsService : ISmsService
    {
        public Task SendSmsAsync(string phoneNumber, string message)
        {
            // Logic to send SMS
            return Task.CompletedTask;
        }
    }
}
