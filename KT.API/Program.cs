using KT.Application.IRepository;
using KT.Application.IService;
using KT.Application.Service;
using KT.Application.Users.Handlers;
using KT.Infrastructure;
using KT.Infrastructure.Repository;
using KT.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ISmsService, SmsService>();
builder.Services.AddScoped<CreateUserHandler>();
builder.Services.AddScoped<SetPinHandler>();
builder.Services.AddScoped<VerifyOtpHandler>();
builder.Services.AddScoped<SendOtpHandler>();
builder.Services.AddScoped<LoginHandler>();

builder.Services.AddScoped<OtpService>();
builder.Services.AddScoped<PinService>();
builder.Services.AddScoped<IOtpRepository, OtpRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
