using System.ComponentModel.Design.Serialization;
using Asp.Versioning;
using Carter;
using demoapi.HostedService;
using demoApiSolution.Database.Infrastructure.MySql;
using demoApiSolution.Database.Repository;
using demoApiSolution.Shared.Interface;
using demoApiSolution.Shared.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

// Add services to the container.
builder.Services.AddHostedService<InitializationService>();
builder.Services.AddControllers();
builder.Services.AddApiVersioning(x =>
{
    x.DefaultApiVersion = new ApiVersion(1, 0);
    x.AssumeDefaultVersionWhenUnspecified = true;
    x.ReportApiVersions = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("V1", new OpenApiInfo { Title = "V1", Version = "V1.0" });
    options.SwaggerDoc("V2", new OpenApiInfo { Title = "V2", Version = "V2.0" });
    options.ResolveConflictingActions(descriptions => descriptions.First());
    options.CustomSchemaIds(x => x.FullName);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IDalService, DalService>();

builder.Services.Configure<SwaggerUIOptions>(options =>
{
    // Enable dark mode and add custom stylesheet
    var path = @"C:\Users\reine\source\repos\demoApiSolution\demoapi\wwwroot";
    options.InjectStylesheet(Path.Combine(path,"swagger-dark.css"));
    options.EnableValidator();
});


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MySql"),
        new MySqlServerVersion(ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySql")))));

builder.Services.AddCarter();

var app = builder.Build();

//AppDbContext on startup
var scope = app.Services.CreateScope();

scope.ServiceProvider.GetService<ApplicationDbContext>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/V1/swagger.json", "V1.0");
        options.SwaggerEndpoint("/swagger/V2/swagger.json", "V2.0");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapCarter();

app.Run();
