using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class PostsService
{
    private readonly TestingDbContext _context;

    public PostsService(TestingDbContext context)
    {
        _context = context;
    }

    public async Task<List<Post>> Get()
    {
        return await _context.Posts.ToListAsync();
    }

    public async Task<Post>? Get(Guid id)
    {
        return await _context.Posts.FirstOrDefaultAsync(e => Guid.Equals(id, e.Id));
    }

    //static public Post? Get(string name)
    //{
    //}

    public async Task<Post> Add(Post newData)
    {
        await _context.Posts.AddAsync(newData);
        return newData;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    //public static Post? Delete(int id)
    //{

    //}

    //static public Post? Add(Post newData)
    //{

    //}
}

