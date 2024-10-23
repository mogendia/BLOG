using BLOG.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.Application.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommandHandler(IBlogRepository blogRepository) : IRequestHandler<DeleteBlogCommand, int>
    {
        public async Task<int> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            return await blogRepository.DeleteBlogAsync(request.Id);
        }
    }
}
