using MartialArtsLibrary.Core.Domain.Content;
using MartialArtsLibrary.Core.Repositories;
using MartialArtsLibrary.Core.SeedWorks;
using MartialArtsLibrary.Data.SeedWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartialArtsLibrary.Data.Repositories
{
    public class PostRepository : RepositoryBase<Post, Guid>, IPostRepository
    {
        public PostRepository(MartialArtsLibraryContext context) : base(context)
        {
        }

        public Task<List<Post>> GetPopularPostAsync(int count)
        {
            return _context.Posts.OrderByDescending(x => x.ViewCount).Take(count).ToListAsync();
        }
    }
}
