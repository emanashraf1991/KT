﻿using KT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT.Application.IService
{
    public interface IUserService
    {
        List<User> GetAllUsers();
    }
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string body);
    }

    public interface ISmsService
    {
        Task SendSmsAsync(string phoneNumber, string message);
    }
}
