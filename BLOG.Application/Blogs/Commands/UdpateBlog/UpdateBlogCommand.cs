using BLOG.Application.Blogs.Queries.GetBlogs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.Application.Blogs.Commands.UdpateBlog
{
    public class UpdateBlogCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
    }
}
