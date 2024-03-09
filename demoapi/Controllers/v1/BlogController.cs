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
    public class BlogController : ControllerBase
    {
        private IDalService _dalService;

        public BlogController(IDalService dalService)
        {
            _dalService = dalService;
        }

        [MapToApiVersion("1.0")]
        [HttpGet("CreateBlog/{userId}/{topic}")]
        public async Task<Blog> Create(int userId, string topic)
        {
            var blog = await _dalService.CreateBlog(userId, topic);
            return blog;
        }

        [MapToApiVersion("1.0")]
        [HttpGet("GetBlog/{topic}")]
        public async Task<Blog?> GetBlogBy(string topic)
        {
            var blog = await _dalService.GetBlogBy(topic);

            return blog;
        }
    }
}
