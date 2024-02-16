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
        var posts = context.PostWithTagsCounts.ToList();

        foreach (var post in posts)
        {
           Console.WriteLine(post.Count);
        }
    }
}