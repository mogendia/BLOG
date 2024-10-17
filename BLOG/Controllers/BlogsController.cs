using BLOG.Application.Blogs.Commands.CreateBlog;
using BLOG.Application.Blogs.Commands.DeleteBlog;
using BLOG.Application.Blogs.Commands.UdpateBlog;
using BLOG.Application.Blogs.Queries.GetBlogs;
using BLOG.Application.Blogs.Queries.GetBlogsById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BLOG.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogsController : ControllerBase
{
    private readonly IMediator _mediator;
    public BlogsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("GetAllBlogs")]
    
    public async Task<IActionResult> GetAllAsync()
    {
        var query = new GetBlogQuery();
        var result =await _mediator.Send(query);
        return Ok(result);
    }
    [HttpGet("Blogs/{id}")]
    public async Task<IActionResult> GetBlogsById(int id)
    {
        return Ok(await _mediator.Send(new GetBlogByIdQuery() { BlogId = id}));
    }
    [HttpPost]
    public async Task<IActionResult> CreateBlog([FromBody] CreateBlogCommand command)
    {
        var add = await _mediator.Send(command);
        return Ok(new { add });
    }
    [HttpPut]
    public async Task<IActionResult> UpdateBlog([FromBody] UpdateBlogCommand command) 
    {
        var edit = await _mediator.Send(command);
        return Ok(new { edit });
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteBlog([FromBody] DeleteBlogCommand command)
    {
        var delete = await _mediator.Send(command);
        return Ok(new { delete });
    }

}
