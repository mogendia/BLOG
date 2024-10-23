using AutoMapper;
using BLOG.Domain.Entities;
using BLOG.Domain.Repositories;
using MediatR;

namespace BLOG.Application.Blogs.Commands.UdpateBlog
{
    public class UpdateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
        : IRequestHandler<UpdateBlogCommand, int>
    {

        public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var updateBlog = new Blog
            {
                Id = request.Id,
                Author = request.Author,
                Description = request.Description,
                Name = request.Name
            };
           return await blogRepository.UpdateBlogAsync(updateBlog);
           
        }
    }
}
