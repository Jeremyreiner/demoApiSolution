using Bogus.DataSets;
using demoApiSolution.Shared.Entity;
using demoApiSolution.Shared.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace demoApiSolution.Shared.Service
{
    public class DalService : IDalService
    {
        private IUserRepository _userRepository;
        private IBlogRepository _blogRepository;
        private Bogus.Faker _faker = new Bogus.Faker();
        public DalService(IUserRepository userRepository, IBlogRepository blogRepository)
        {
            _userRepository = userRepository;
            _blogRepository = blogRepository;
        }
        public async Task<User> CreateUser(string name)
        {
            var user = new User
            {
                Name = name,
                Email = _faker.Person.Email,
                Password = _faker.Person.Phone,
                UserName = _faker.Person.UserName
            };

            await _userRepository.CreateUser(user);

            return user;
        }

        public async Task<User?> GetUserBy(string name)
        {
            return await _userRepository.GetUserByAsync(x => x.Name == name);
        }

        public async Task<Blog> CreateBlog(int userId, string topic)
        {
            var user = await _userRepository.GetUserByAsync(x => x.Id == userId);
            // if (user == null)
            // { 
            //     throw new NullReferenceException();
            // }

            ArgumentNullException.ThrowIfNull(user);

            var blog = new Blog
            {
                Topic = topic,
                UserId = userId,
                User = user
            };

            await _blogRepository.CreateBlog(blog);

            return blog;
        }

        public async Task<Blog?> GetBlogBy(string topic)
        {
            return await _blogRepository.GetBlogBy(x => x.Topic.ToLower() == topic.ToLower());
        }

    }
}
