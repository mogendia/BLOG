using BLOG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.Domain.Repositories
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllBlogAsync();
        Task<Blog> GetBlogByIdAsync(int id);
        Task<Blog> CreateBlogAsync(Blog blog);
        Task<int> UpdateBlogAsync( Blog blog );
        Task<int> DeleteBlogAsync(int id);


    }
}
