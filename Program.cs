using System.Formats.Tar;
using BlogEntityFramework.Data;
using BlogEntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogEntityFramework;

public static class Program
{
    public static void Main(string[] args)
    {
        using var context = new BlogDataContext();

        var posts = context.Posts
            .Include(x => x.Author)
            .ThenInclude(x => x.Roles)
            .Include(x => x.Tags);

        foreach (var post in posts)
        {
            foreach (var tag in post.Tags)
            {
                
            }
        }
    }
}