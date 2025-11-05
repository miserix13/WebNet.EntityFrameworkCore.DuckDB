using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebNet.EntityFrameworkCore.DuckDB
{
    public static class DuckDBDbContextOptionsBuilderExtensions
    {
        public static DbContextOptionsBuilder UseDuckDB(this DbContextOptionsBuilder optionsBuilder, string connectionString)
        {
            var extension = new DuckDBOptionsExtension(connectionString);
            ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(extension);
            return optionsBuilder;
        }
    }
}
