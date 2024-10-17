using BLOG.Application.Blogs.Queries.GetBlogs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommand : IRequest<BlogVm>
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
    }
}
