using MartialArtsLibrary.Core.Domain.Content;
using MartialArtsLibrary.Core.Model;
using MartialArtsLibrary.Core.Model.Content;
using MartialArtsLibrary.Core.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartialArtsLibrary.Core.Repositories
{
    public interface IPostRepository:IRepository<Post, Guid>
    {
        Task<List<Post>> GetPopularPostAsync(int count);
        Task<PagedResult<PostInListDto>> GetPostsPagingAsync(string keyword, Guid? categoryId, int pageIndex = 1, int pageSize = 10);
    }
}
