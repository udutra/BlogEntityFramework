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
        var posts = GetPosts(context);
        posts = GetPosts(context, 0 , 25);
        posts = GetPosts(context, 25, 25);
        posts = GetPosts(context, 50 , 25);
        posts = GetPosts(context, 750 , 25);
    }

    private static List<Post> GetPosts(BlogDataContext context, int skip = 0, int take = 25)
    {
        var posts = context
            .Posts
            .AsNoTracking()
            .Skip(skip)
            .Take(take)
            .ToList();
        return posts;
    }
}