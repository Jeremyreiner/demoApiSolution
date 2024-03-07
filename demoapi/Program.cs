using System.ComponentModel.Design.Serialization;
using demoApiSolution.Database.Infrastructure.MySql;
using demoApiSolution.Database.Repository;
using demoApiSolution.Shared.Interface;
using demoApiSolution.Shared.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IDalService, DalService>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MySql"),
        new MySqlServerVersion(ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySql")))));


var app = builder.Build();

//AppDbContext on startup
var scope = app.Services.CreateScope();

scope.ServiceProvider.GetService<ApplicationDbContext>();

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
