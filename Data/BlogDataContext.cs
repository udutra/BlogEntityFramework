﻿using BlogEntityFramework.Data.Mappings;
using BlogEntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogEntityFramework.Data;

public class BlogDataContext : DbContext
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<PostWithTagsCount> PostWithTagsCounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(
            "Server=localhost,1433;Database=BlogFluentMap;User ID=sa;Password=Dutra140391;TrustServerCertificate=True");
        //options.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryMap());
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new PostMap());
        modelBuilder.Entity<PostWithTagsCount>(x =>
        {
            x.ToSqlQuery("SELECT [Title] AS [NAME], (SELECT COUNT ([Id]) FROM [Tag] WHERE [Post].[Id] = [Id]) AS [COUNT] FROM [Post]");
        });
    }
}