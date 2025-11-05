using Microsoft.EntityFrameworkCore.Storage;
using System.Threading;
using System.Threading.Tasks;
using System.Data.Common;
using DuckDB.NET.Data;

namespace WebNet.EntityFrameworkCore.DuckDB
{
    public class DuckDBDatabaseCreator : RelationalDatabaseCreator
    {
        public DuckDBDatabaseCreator(RelationalDatabaseCreatorDependencies dependencies)
            : base(dependencies)
        {
        }

        public override void Create()
        {
            // For file-based DuckDB, creating the database is opening the file
            // For DuckLake, ensure the connection is valid
        }

        public override async Task CreateAsync(CancellationToken cancellationToken = default)
        {
            Create();
            await Task.CompletedTask;
        }

        public override bool Exists()
        {
            // Check if the file exists for file-based, or if DuckLake connection is valid
            return true;
        }

        public override async Task<bool> ExistsAsync(CancellationToken cancellationToken = default)
        {
            return Exists();
        }

        public override void Delete()
        {
            // Delete the file for file-based DuckDB
        }

        public override async Task DeleteAsync(CancellationToken cancellationToken = default)
        {
            Delete();
            await Task.CompletedTask;
        }

        public override bool HasTables()
        {
            // Implement logic to check if any tables exist in the DuckDB database
            return true;
        }
    }
}
