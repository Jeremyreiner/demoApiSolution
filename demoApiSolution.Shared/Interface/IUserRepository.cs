using demoApiSolution.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace demoApiSolution.Shared.Interface
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task<User?> GetUserByAsync(Expression<Func<User, bool>> predicate);
    }
}
