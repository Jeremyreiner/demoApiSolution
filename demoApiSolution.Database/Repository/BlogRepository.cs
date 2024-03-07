using demoApiSolution.Database.Infrastructure.MySql;
using demoApiSolution.Shared.Entity;
using demoApiSolution.Shared.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace demoApiSolution.Database.Repository
{
    public class BlogRepository : IBlogRepository
    {
        readonly ApplicationDbContext _DbContext;
         
        public BlogRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task CreateBlog(Blog blog)
        {
            await _DbContext.Blogs.AddAsync(blog);

            await _DbContext.SaveChangesAsync();

        }

        public async Task<Blog?> GetBlogBy(Expression<Func<Blog, bool>> predicate)
        {
            return await _DbContext.Blogs.FirstOrDefaultAsync(predicate);
        }

    }
}
