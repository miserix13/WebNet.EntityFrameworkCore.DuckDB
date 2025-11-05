
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace WebNet.EntityFrameworkCore.DuckDB
{
    public class DuckDBOptionsExtension : IDbContextOptionsExtension
    {
        private DbContextOptionsExtensionInfo _info;
        public string ConnectionString { get; }

        public DuckDBOptionsExtension(string connectionString)
        {
            ConnectionString = connectionString;
            _info = new ExtensionInfo(this);
        }

        public DbContextOptionsExtensionInfo Info => _info;

        public void ApplyServices(IServiceCollection services)
        {
            // Register DuckDB provider services here
            // Register the database creator
            services.AddScoped<Microsoft.EntityFrameworkCore.Storage.IRelationalDatabaseCreator, DuckDBDatabaseCreator>();
            // Register the migrations SQL generator
            services.AddScoped<Microsoft.EntityFrameworkCore.Migrations.IMigrationsSqlGenerator, DuckDBMigrationsSqlGenerator>();
            // TODO: Add connection string handling for file-based, in-memory, and DuckLake scenarios
        }

        public void Validate(IDbContextOptions options)
        {
            // Add validation logic if needed
        }

    private class ExtensionInfo : DbContextOptionsExtensionInfo
        {
            public ExtensionInfo(IDbContextOptionsExtension extension) : base(extension) { }
            public override bool IsDatabaseProvider => true;
            public override string LogFragment => "Using DuckDB";
            public override int GetServiceProviderHashCode() => 0;
            public override void PopulateDebugInfo(IDictionary<string, string> debugInfo) { }
            public override bool ShouldUseSameServiceProvider(DbContextOptionsExtensionInfo other) => false;
        }
    }
}
