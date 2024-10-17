using AutoMapper;
using BLOG.Application.Blogs.Queries.GetBlogs;
using BLOG.Domain.Entities;
using BLOG.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.Application.Blogs.Commands.UdpateBlog
{
    public class UdpateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public UdpateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var updateBlog = new Blog
            {
                Id = request.Id,
                Author = request.Author,
                Description = request.Description,
                Name = request.Name
            };
           return await _blogRepository.UpdateBlogAsync(updateBlog);
           
        }
    }
}
/*
  public async Task<BlogVm> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
      {
          var updateBlog = new Blog
          {
              Id = request.Id ,
              Author=request.Author,
              Description=request.Description,
              Name=request.Name
          };
          var result = await _blogRepository.UpdateBlogAsync(request.Id,updateBlog);
          return _mapper.Map<BlogVm>(result);
      }
 */