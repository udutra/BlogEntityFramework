using System.Formats.Tar;
using BlogEntityFramework.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogEntityFramework;

public static class Program
{
    public static void Main(string[] args)
    {
        //Lazy Loading
        using var context = new BlogDataContext();
        var posts = context.Posts;

        foreach (var post in posts)
        {
            foreach (var tag in post.Tags)
            {
                
            }
        }
        
        //Eager Loading
        var posts2 = context.Posts.Include(x => x.Tags);

        foreach (var post in posts2)
        {
            foreach (var tag in post.Tags)
            {
                
            }
        }
    }
}