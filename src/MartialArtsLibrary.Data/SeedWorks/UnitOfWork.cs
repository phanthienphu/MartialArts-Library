using AutoMapper;
using MartialArtsLibrary.Core.Repositories;
using MartialArtsLibrary.Core.SeedWorks;
using MartialArtsLibrary.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartialArtsLibrary.Data.SeedWorks
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly MartialArtsLibraryContext _context;

        public UnitOfWork(MartialArtsLibraryContext context, IMapper mapper)
        {
            _context = context;
            Posts = new PostRepository(context, mapper);
        }

        public IPostRepository Posts { get; private set; }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
