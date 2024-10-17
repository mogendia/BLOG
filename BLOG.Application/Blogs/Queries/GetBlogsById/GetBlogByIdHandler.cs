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
    public class GetBlogByIdHandler : IRequestHandler<GetBlogByIdQuery, BlogVm>
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;

        public GetBlogByIdHandler(IMapper mapper,IBlogRepository blogRepository)
        {
            _mapper = mapper;
            _blogRepository = blogRepository;
        }
        public async Task<BlogVm> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogRepository.GetBlogByIdAsync(request.BlogId);
            var list = _mapper.Map<BlogVm>(blogs);
            return list;
        }
    }
}
