using demoApiSolution.Database.Infrastructure.MySql;
using demoApiSolution.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using demoApiSolution.Shared.Interface;
using Microsoft.EntityFrameworkCore;

namespace demoApiSolution.Database.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly ApplicationDbContext _DbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task CreateUser(User user)
        {
            await _DbContext.Users.AddAsync(user);

            await _DbContext.SaveChangesAsync();

        }

        public async Task<User?> GetUserByAsync(Expression<Func<User, bool>> predicate) =>
            await _DbContext.Users.FirstOrDefaultAsync(predicate);

    }
}
