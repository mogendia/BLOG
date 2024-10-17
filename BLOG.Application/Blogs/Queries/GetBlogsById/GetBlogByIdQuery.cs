using BLOG.Application.Blogs.Queries.GetBlogs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.Application.Blogs.Queries.GetBlogsById
{
    public class GetBlogByIdQuery : IRequest<BlogVm>
    {
        public int BlogId { get; set; }
    }
}
