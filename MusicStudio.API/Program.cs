using Microsoft.AspNetCore.Authentication;
using MusicStudio.Application.Commands.CreateUserCommand;
using MusicStudio.Core.Services;
using MusicStudio.Infraestructure.Auth;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMediatR(opt => opt.RegisterServicesFromAssemblyContaining(typeof(CreateUserCommand)));
builder.Services.AddScoped<IAuthService, AuthService>();
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
