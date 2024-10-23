using AutoMapper;
using BLOG.Application.Blogs.Queries.GetBlogs;
using BLOG.Domain.Entities;
using BLOG.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
        : IRequestHandler<CreateBlogCommand, BlogVm>
    {
        public async Task<BlogVm> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {


            var blog = new Blog
            {
                Author = request.Author,
                Name = request.Name,
                Description = request.Description,
            };

            var result = await blogRepository.CreateBlogAsync(blog);
            return mapper.Map<BlogVm>(result);

        }
    }
}
