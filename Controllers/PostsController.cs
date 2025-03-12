using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;
[ApiController]
[Route("[controller]")]
public class PostsController : Controller
{
    private readonly PostsService _postsServicel;

    public PostsController(PostsService postsServicel)
    {
        _postsServicel = postsServicel;
    }

    [HttpGet]
    public async Task<List<Post>> Get()
    {
        return await _postsServicel.Get();
    }

    [HttpGet("{id}")]
    public async Task<Object> Get(string id)
    {
        if (Guid.TryParse(id, out var postId))
        {
            Post? post = await _postsServicel.Get(postId);
            if (post is null)
            {
                Response.StatusCode = 404;
                return new { State = "Not Found" };
            };

            return post;
        } else
        {
            Response.StatusCode = 400;
            return new { State = "Bad Request" };
        }
    }

    [HttpPost]
    public async Task<Post> Post(Post data)
    {
        Post newPost = await _postsServicel.Add(data);
        await _postsServicel.SaveChangesAsync();
        return newPost;
    }
}
