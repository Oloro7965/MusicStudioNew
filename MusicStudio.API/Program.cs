using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using MusicStudio.Application.Commands.CreateUserCommand;
using MusicStudio.Core.Domain.Repositories;
using MusicStudio.Core.Services;
using MusicStudio.Infraestructure.Auth;
using MusicStudio.Infraestructure.MessageBus;
using MusicStudio.Infraestructure.Persistance;
using MusicStudio.Infraestructure.Persistance.Repositories;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MusicStudio");
builder.Services.AddDbContext<MusicStudioDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddMediatR(opt => opt.RegisterServicesFromAssemblyContaining(typeof(CreateUserCommand)));
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<ITimeRepository, TimeRepository>();
builder.Services.AddScoped<ISchedulingRepository, SchedulingRepository>();
builder.Services.AddHttpClient();

// RabbitMQ
var connectionFactory = new ConnectionFactory
{
    HostName = "localhost"
};
var connection = connectionFactory.CreateConnection("musicstudio-service-producer");
builder.Services.AddSingleton(connection);
builder.Services.AddSingleton<IMessageBusClient, RabbitMqClient>();
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
