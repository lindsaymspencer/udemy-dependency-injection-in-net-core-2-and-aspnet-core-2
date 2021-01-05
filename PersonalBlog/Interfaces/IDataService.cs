using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalBlog.Models;

namespace PersonalBlog.Interfaces
{
    public interface IDataService
    {
        Task Create(Post model);
        Task<List<Post>> GetAll();
    }
}
