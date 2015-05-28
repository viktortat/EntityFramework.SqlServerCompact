﻿using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.FunctionalTests;
using Microsoft.Data.Entity.FunctionalTests.TestModels.ComplexNavigationsModel;
using Microsoft.Data.Entity.Relational.FunctionalTests;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;

namespace ErikEJ.Data.Entity.SqlServerCe.FunctionalTests
{
    public class ComplexNavigationsQuerySqlCeFixture : ComplexNavigationsQueryRelationalFixture<SqlCeTestStore>
    {
        public static readonly string DatabaseName = "ComplexNavigations";

        private readonly IServiceProvider _serviceProvider;

        private readonly string _connectionString = SqlCeTestStore.CreateConnectionString(DatabaseName);

        public ComplexNavigationsQuerySqlCeFixture()
        {
            _serviceProvider = new ServiceCollection()
                .AddEntityFramework()
                .AddSqlCe()
                .ServiceCollection()
                .AddSingleton(TestSqlCeModelSource.GetFactory(OnModelCreating))
                .AddInstance<ILoggerFactory>(new TestSqlLoggerFactory())
                .BuildServiceProvider();
        }

        public override SqlCeTestStore CreateTestStore() =>
            SqlCeTestStore.GetOrCreateShared(
                DatabaseName,
                () =>
                {
                    var optionsBuilder = new EntityOptionsBuilder();
                    optionsBuilder.UseSqlCe(_connectionString);

                    using (var context = new ComplexNavigationsContext(_serviceProvider, optionsBuilder.Options))
                    {
                        if (context.Database.EnsureCreated())
                        {
                            ComplexNavigationsModelInitializer.Seed(context);
                        }

                        TestSqlLoggerFactory.SqlStatements.Clear();
                    }
                });

        public override ComplexNavigationsContext CreateContext(SqlCeTestStore testStore)
        {
            var optionsBuilder = new EntityOptionsBuilder();
            optionsBuilder.UseSqlCe(testStore.Connection);

            var context = new ComplexNavigationsContext(_serviceProvider, optionsBuilder.Options);
            context.Database.AsRelational().Connection.UseTransaction(testStore.Transaction);

            return context;
        }
    }
}
