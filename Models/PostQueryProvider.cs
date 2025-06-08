using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogoSphere.Models
{
    public class PostQueryProvider
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Post> GetPosts([Service] BlogDbContext context) => context.Posts;
        
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Comment> GetComments([Service] BlogDbContext context) => context.Comments;
    }
}