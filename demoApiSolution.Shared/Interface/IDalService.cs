using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using demoApiSolution.Shared.Entity;

namespace demoApiSolution.Shared.Interface
{
    public interface IDalService
    {
        public Task<User> CreateUser(string name);
        public Task<User?> GetUserBy(string name);

        public Task<Blog> CreateBlog(int userId, string topic);
        public Task<Blog?> GetBlogBy(string topic);
    }
}
