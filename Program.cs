using BlogEntityFramework.Data;
using BlogEntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogEntityFramework;

public static class Program
{
    public static void Main(string[] args)
    {
        using var context = new BlogDataContext();

        /*var user = new User
        {
            Name = "Guilherme Dutra",
            Slug = "guilherme-dutra",
            Email = "guilherme@balta.io",
            Bio = "9x Microsoft MVP",
            Image = "https://balta.io",
            PasswordHash = "123098457"
        };

        var category = new Category
        {
            Name = "Backend",
            Slug = "backend"
        };

        var post = new Post
        {
            Author = user,
            Category = category,
            Body = "<p>Hello world</p>",
            Slug = "comecando-com-ef-core",
            Summary = "Neste artigo vamos aprender EF Core",
            Title = "Começando com EF Core",
            CreateDate = DateTime.Now,
            LastUpdateDate = DateTime.Now
        };
        context.Posts.Add(post);
        context.SaveChanges();
        */

        /*var posts = context
            .Posts
            .AsNoTracking()
            .Include(x => x.Author)
            .Include(x => x.Category)
                //.ThenInclude() SubSelect
            //.Where(x => x.AuthorId == 9)
            .OrderByDescending(x => x.LastUpdateDate)
            .ToList();

        foreach (var post in posts)
        {
            Console.WriteLine($"{post.Title} escrito por {post.Author?.Name} em {post.Category.Name}!");
        }*/
        
        var post = context
            .Posts
            .Include(x => x.Author)
            .Include(x => x.Category)
            .OrderByDescending(x => x.LastUpdateDate)
            .FirstOrDefault();
        post.Author.Name = "Teste";
        context.Posts.Update(post);
        context.SaveChanges();
    }
}