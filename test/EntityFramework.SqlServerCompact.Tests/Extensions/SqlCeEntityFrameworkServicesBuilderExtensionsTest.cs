﻿using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.SqlServerCompact;
using Microsoft.Data.Entity.SqlServerCompact.Migrations;
using Microsoft.Data.Entity.SqlServerCompact.Update;
using Microsoft.Data.Entity.SqlServerCompact.ValueGeneration;
using Microsoft.Data.Entity.Tests;
using Microsoft.Data.Entity.Update;
using Xunit;

namespace ErikEJ.Data.Entity.SqlServerCe.Tests.Extensions
{
    public class SqlCeEntityFrameworkServicesBuilderExtensionsTest : RelationalEntityFrameworkServicesBuilderExtensionsTest
    {
        [Fact]
        public override void Services_wire_up_correctly()
        {
            base.Services_wire_up_correctly();

            // Relational
            VerifySingleton<IComparer<ModificationCommand>>();

            // SQL Server Ce dingletones
            VerifySingleton<SqlCeConventionSetBuilder>();
            VerifySingleton<SqlCeValueGeneratorCache>();
            VerifySingleton<SqlCeUpdateSqlGenerator>();
            VerifySingleton<SqlCeTypeMapper>();            
            VerifySingleton<SqlCeModelSource>();

            // SQL Server Ce scoped
            VerifyScoped<SqlCeModificationCommandBatchFactory>();
            VerifyScoped<SqlCeDatabaseProviderServices>();
            VerifyScoped<SqlCeDatabaseConnection>();
            VerifyScoped<SqlCeMigrationsAnnotationProvider>();
            VerifyScoped<SqlCeMigrationsSqlGenerator>();
            VerifyScoped<SqlCeDatabaseCreator>();

            // Migrations
            VerifyScoped<IMigrationsAssembly>();
            VerifyScoped<SqlCeHistoryRepository>();
            VerifyScoped<IMigrator>();
            VerifySingleton<IMigrationsIdGenerator>();
            VerifyScoped<IMigrationsModelDiffer>();
            VerifyScoped<SqlCeMigrationsSqlGenerator>();
        }

        public SqlCeEntityFrameworkServicesBuilderExtensionsTest()
            : base(SqlCeTestHelpers.Instance)
        {
        }
    }
}
