using System.Net;
using Asp.Versioning;
using Carter;
using demoApiSolution.Shared.Entity;
using demoApiSolution.Shared.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace demoapi.Controllers.v3
{
    public class UserController : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("Minimal/Users/");
            group.MapGet("Create/{name}", Create);
            group.MapGet("Get/{name}", GetUserBy);
        }
        
         private async Task<Result<User>> Create(string name, IDalService dalService, ILogger<UserController> logger)
        {
            var user = await dalService.CreateUser(name);
            var result = Result<User>.Success(user);

            return result;
        }

         private async Task<Result<User>> GetUserBy(string name, IDalService dalService, ILogger<UserController> logger)
        {
            var user = await dalService.GetUserBy(name);

            return user == null 
                ? Result<User>.Failed(new Error(HttpStatusCode.NotFound)) 
                : Result<User>.Success(user);
        }

        
    }
}
