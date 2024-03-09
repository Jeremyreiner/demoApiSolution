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
    public class BlogController : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("Minimal/blogs/");

            group.MapGet("Create/{blog}", Create);
            group.MapGet("Get/{topic}", GetBlogByResult);
        }

        private async Task<Result<Blog>> Create(int userId, string topic, IDalService dalService, ILogger<BlogController> logger)
        {
            var blog = await dalService.CreateBlog(userId, topic);

            var result = Result<Blog>.Success(blog);

            if (result.IsSuccess)
            {
                logger.LogInformation("blog created");
            }
            else
            {
                logger.LogError("blog not created");
            }

            return result;
        }

        private async Task<Result<Blog>> GetBlogByResult(string topic, IDalService dalService, ILogger<BlogController> logger)
        {
            var blog = await dalService.GetBlogBy(topic);

            if (blog == null)
            {
                return Result<Blog>.Failed(new Error(HttpStatusCode.NotFound));
            }

            var result = Result<Blog>.Success(blog);

            return result;
        }
    }
}
