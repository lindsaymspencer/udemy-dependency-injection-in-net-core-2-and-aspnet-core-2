using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using PersonalBlog.Interfaces;
using PersonalBlog.Models;

namespace PersonalBlog.Services
{
    public class DynanmoDbDataService : IDataService
    {
        private readonly IDynamoDBContext _context;

        public DynanmoDbDataService(IDynamoDBContext context)
        {
            _context = context;
        }
        public async Task Create(Post model)
        {
            await _context.SaveAsync<Post>(model);
        }

        public Task<List<Post>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
