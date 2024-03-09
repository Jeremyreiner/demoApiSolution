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
    public class BlogController : ControllerBase
    {
        private IDalService _dalService;
        public BlogController(IDalService dalService)
        {
            _dalService = dalService;
        }

        [MapToApiVersion("2.0")]
        [HttpGet("CreateBlog/{userId}/{topic}")]
        public async Task<Result<Blog>> Create(int userId, string topic)
        {
            var blog = await _dalService.CreateBlog(userId, topic);

            return Result<Blog>.Success(blog);
        }

        [MapToApiVersion("2.0")]
        [HttpGet("GetBlog/{topic}")]
        public async Task<Result<Blog>> GetBlogByResult(string topic)
        {
            var blog = await _dalService.GetBlogBy(topic);

            if (blog == null)
            {
                return Result<Blog>.Failed(new Error(HttpStatusCode.NotFound));
            }

            var result = Result<Blog>.Success(blog);

            return result;
        }
    }
}
