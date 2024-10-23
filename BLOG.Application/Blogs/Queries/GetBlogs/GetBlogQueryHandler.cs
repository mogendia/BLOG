using AutoMapper;
using BLOG.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.Application.Blogs.Queries.GetBlogs
{
    public class GetBlogQueryHandler(IBlogRepository blogRepository, IMapper mapper)
        : IRequestHandler<GetBlogQuery, List<BlogVm>>
    {
        public async Task<List<BlogVm>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var blogs = await blogRepository.GetAllBlogAsync();
            return  mapper.Map<List<BlogVm>>(blogs);
            
        }
    }
}
