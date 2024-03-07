using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using demoApiSolution.Shared.Entity;

namespace demoApiSolution.Shared.Interface
{
    public interface IBlogRepository
    {
        Task CreateBlog(Blog blog);
        Task<Blog?> GetBlogBy(Expression<Func<Blog, bool>> predicate);
    }
}
