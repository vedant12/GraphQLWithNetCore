using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogoSphere.Models;
using Microsoft.EntityFrameworkCore;
using Faker;

namespace BlogoSphere.SeedData
{
    public static class DataSeeder
    {
        public async static Task SeedData(BlogDbContext context)
        {
            var posts = await context.Posts.AnyAsync();

            if (!posts)
            {
                for (int i = 0; i < 10; i++)
                {
                    #pragma warning disable CS8601 // Possible null reference assignment.
                    var post = new Post()
                    {
                        Title = Lorem.Sentence(),
                        Author = Name.FullName(),
                        Content = Lorem.Paragraphs(3).FirstOrDefault(),
                        CreatedAt = DateTime.Now,
                    };
                    #pragma warning restore CS8601 // Possible null reference assignment.   

                    await context.Posts.AddAsync(post);

                    for (int j = 1; j <= 10; j++)
                    {
                        var comment = new Comment
                        {
                            Content = Lorem.Sentence(),
                            Author = Name.FullName(),
                            CreatedAt = DateTime.Now,
                            Post = post
                        };

                        await context.Comments.AddAsync(comment);
                    }
                }

                await context.SaveChangesAsync();
            }
        }
    }
}