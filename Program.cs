using BlogEntityFramework.Data;
using BlogEntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogEntityFramework;

public static class Program
{
    public static void Main(string[] args)
    {
        using var context = new BlogDataContext();

        var user = new User
        {
            Name = "Guilherme Dutra",
            Email = "guilherme@balta.io",
            PasswordHash = "123098457",
            Bio = "9x Microsoft MVP",
            Image = "https://balta.io",
            Slug = "guilherme-dutra"
        };
        
        context.Users.Add(user);
        context.SaveChanges();

        var user2 = context.Users.FirstOrDefault();
        var post = new Post
        {
            Author = user2,
            Body = "Meu Artigo",
            Category = new Category
            {
              Name  = "BackEnd",
              Slug = "bacend"
            },
            CreateDate = System.DateTime.Now,
            //LastUpdateDate
            Slug = "meu-artigo",
            Summary = "Neste artigo vamos conferir...",
            //Tags=null,
            Title = "Meu artigo"
        };
        context.Posts.Add(post);
        context.SaveChanges();
        


    }
}