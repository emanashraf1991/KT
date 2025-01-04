using KT.Application.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public Task SendEmailAsync(string email, string subject, string body)
        {
            // Logic to send email
            return Task.CompletedTask;
        }
    }
}
