using MartialArtsLibrary.Core.Domain.Content;
using MartialArtsLibrary.Core.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartialArtsLibrary.Core.Repositories
{
    public interface IPostRepository:IRepository<Post,Guid>
    {
        Task<List<Post>> GetPopularPostAsync(int count);
    }
}
