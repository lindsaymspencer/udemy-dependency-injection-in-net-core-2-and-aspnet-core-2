using System.Collections.Generic;
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

        public async Task<List<Post>> GetAll()
        {
            return await _context.ScanAsync<Post>(new List<ScanCondition>()).GetRemainingAsync();
        }
    }
}
