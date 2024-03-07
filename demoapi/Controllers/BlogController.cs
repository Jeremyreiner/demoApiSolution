using demoApiSolution.Shared.Entity;
using demoApiSolution.Shared.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace demoapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private IDalService _dalService;
        public BlogController(IDalService dalService)
        {
            _dalService = dalService;
        }

        [HttpGet("CreateBlog/{userId}/{topic}")]
        public async Task<Blog> Create(int userId, string topic)
        {
            var blog = await _dalService.CreateBlog(userId, topic);
            return blog;
        }

        [HttpGet("GetBlog/{topic}")]
        public async Task<Blog?> GetBlogBy(string topic)
        {
            var blog = await _dalService.GetBlogBy(topic);

            return blog;
        }
    }
}
