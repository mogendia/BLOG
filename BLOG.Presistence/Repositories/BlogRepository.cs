using BLOG.Domain.Entities;
using BLOG.Domain.Repositories;
using BLOG.Presistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.Presistence.Repositories
{
    public class BlogRepository(BlogDbContext context) : IBlogRepository
    {
        public async Task<Blog> CreateBlogAsync(Blog blog)
        {
            await context.Blogs.AddAsync(blog);
            await context.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteBlogAsync(int id)
        {
           return await context.Blogs.Where(ctg => ctg.Id == id).ExecuteDeleteAsync();
        }

        public async Task<List<Blog>> GetAllBlogAsync()
        {
            var blog = await context.Blogs.ToListAsync();
            return blog;
        }

        public async Task<Blog> GetBlogByIdAsync(int id)
        {
            return await context.Blogs.FindAsync(id);
        }

        public async Task<int> UpdateBlogAsync(Blog blog)
        {
            var edit = await context.Blogs.FindAsync(blog.Id);
            if (edit == null)
                throw new Exception("id not found");
            blog.Id = edit.Id;
            blog.Author = edit.Author;
            blog.Description = edit.Description;
            blog.Name = edit.Name;
            await context.SaveChangesAsync();
            return blog.Id;

        }
    }
}
