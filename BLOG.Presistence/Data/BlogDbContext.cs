using BLOG.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BLOG.Presistence.Data
{
    public class BlogDbContext :IdentityDbContext<ApplicationUser>
    {
       

        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }

       

        public DbSet<Blog>Blogs { get; set; }
       
    }
}
