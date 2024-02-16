﻿using BlogEntityFramework.Data;
using BlogEntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogEntityFramework;

public static class Program
{
    public static async Task Main(string[] args)
    {
        await using var context = new BlogDataContext();

        var post = await context.Posts.ToListAsync();
        var tags = await context.Tags.ToListAsync();

        var posts = GetPosts(context);

        Console.WriteLine("Teste");
        
        /*var user = new User
        {
            Name = "Guilherme Dutra",
            Email = "guilherme@balta.io",
            PasswordHash = "123098457",
            Bio = "9x Microsoft MVP",
            Image = "https://balta.io",
            Slug = "guilherme-dutra",
            Github = "guilhermedutra"
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
              Slug = "backend"
            },
            CreateDate = System.DateTime.Now,
            //LastUpdateDate
            Slug = "meu-artigo",
            Summary = "Neste artigo vamos conferir...",
            //Tags=null,
            Title = "Meu artigo"
        };
        context.Posts.Add(post);
        context.SaveChanges();*/
    }

    public static async Task<List<Post>> GetPosts(BlogDataContext context)
    {
        return await context.Posts.ToListAsync();
    }
    
}