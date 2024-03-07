using demoApiSolution.Shared.Entity;
using demoApiSolution.Shared.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace demoapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IDalService _dalService;
        public UserController(IDalService dalService)
        {
            _dalService = dalService;
        }

        [HttpGet("CreateUser/{name}")]
        public async Task<User> Create(string name)
        {
            var user = await _dalService.CreateUser(name);
            return user;
        }

        [HttpGet("GetUser/{name}")]
        public async Task<User?> GetUserBy(string name)
        {
            var user = await _dalService.GetUserBy(name);

            return user;
        }
    }
}
