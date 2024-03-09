using Asp.Versioning;
using demoApiSolution.Shared.Entity;
using demoApiSolution.Shared.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace demoapi.Controllers.v1
{
    [Route("v1/[controller]")]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "V1")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IDalService _dalService;
        public UserController(IDalService dalService)
        {
            _dalService = dalService;
        }

        [MapToApiVersion("1.0")]
        [HttpGet("CreateUser/{name}")]
        public async Task<User> Create(string name)
        {
            var user = await _dalService.CreateUser(name);
            return user;
        }

        [MapToApiVersion("1.0")]
        [HttpGet("GetUser/{name}")]
        public async Task<User?> GetUserBy(string name)
        {
            var user = await _dalService.GetUserBy(name);

            return user;
        }
    }
}
