using AutoMapper;
using BLOG.Application.Blogs.Queries.GetBlogs;
using BLOG.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.Application.Blogs.Queries.GetBlogsById
{
    public class GetBlogByIdHandler(IMapper mapper, IBlogRepository blogRepository)
        : IRequestHandler<GetBlogByIdQuery, BlogVm>
    {
        public async Task<BlogVm> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var blogs = await blogRepository.GetBlogByIdAsync(request.BlogId);
            return mapper.Map<BlogVm>(blogs);
            
        }
    }
}
