using System.Net;
using Asp.Versioning;
using demoApiSolution.Shared.Entity;
using demoApiSolution.Shared.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace demoapi.Controllers.v2
{
    [Route("v2/[controller]")]
    [ApiVersion("2.0")]
    [ApiExplorerSettings(GroupName = "V2")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IDalService _dalService;
        public UserController(IDalService dalService)
        {
            _dalService = dalService;
        }

        [MapToApiVersion("2.0")]
        [HttpGet("CreateUser/{name}")]
        public async Task<Result<User>> Create(string name)
        {
            var user = await _dalService.CreateUser(name);
            return Result<User>.Success(user);
        }

        [MapToApiVersion("2.0")]
        [HttpGet("GetUser/{name}")]
        public async Task<Result<User>> GetUserBy(string name)
        {
            var user = await _dalService.GetUserBy(name);

            if (user == null)
            {
                return Result<User>.Failed(new Error(HttpStatusCode.NotFound));
            }

            return Result<User>.Success(user);
        }
    }
}
