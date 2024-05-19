using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartialArtsLibrary.Data
{
    public class MartialArtsLibraryContextFactory : IDesignTimeDbContextFactory<MartialArtsLibraryContext>
    {
        public MartialArtsLibraryContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();
            var builder = new DbContextOptionsBuilder<MartialArtsLibraryContext>();
            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            return new MartialArtsLibraryContext(builder.Options);
        }
    }
}
