using Users.Persistence.DataBase;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;
using UserAdministrator.Services.BusinessValidator.Interface;
using UserAdministrator.Services.BusinessValidator.Service;
using UserAdministrator.Services.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("UserConnectionString")
    );

}, ServiceLifetime.Transient, ServiceLifetime.Transient);

// Registramos los EventHandlers para que los relacione con los métodos correspondientes
builder.Services.AddMediatR(Assembly.Load("UserAdministrator.Services.Commands"));

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IUserQueries, UserQueries>();


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
