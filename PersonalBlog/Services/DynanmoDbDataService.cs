using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalBlog.Interfaces;
using PersonalBlog.Models;

namespace PersonalBlog.Services
{
    public class DynanmoDbDataService : IDataService
    {
        public Task Create(Post model)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
