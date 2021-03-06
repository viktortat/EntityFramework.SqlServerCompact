﻿using System.Linq;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Specification.Tests
{
    public class IncludeOneToOneSqlCeTest : IncludeOneToOneTestBase, IClassFixture<OneToOneQuerySqlCeFixture>
    {
        public override void Include_person()
        {
            base.Include_person();

            Assert.Equal(
                @"SELECT [a].[Id], [a].[City], [a].[Street], [p].[Id], [p].[Name]
FROM [Address] AS [a]
INNER JOIN [Person] AS [p] ON [a].[Id] = [p].[Id]",
                Sql);
        }

        public override void Include_person_shadow()
        {
            base.Include_person_shadow();

            Assert.Equal(
                @"SELECT [a].[Id], [a].[City], [a].[PersonId], [a].[Street], [p].[Id], [p].[Name]
FROM [Address2] AS [a]
INNER JOIN [Person2] AS [p] ON [a].[PersonId] = [p].[Id]",
                Sql);
        }

        public override void Include_address()
        {
            base.Include_address();

            Assert.Equal(
                @"SELECT [p].[Id], [p].[Name], [a].[Id], [a].[City], [a].[Street]
FROM [Person] AS [p]
LEFT JOIN [Address] AS [a] ON [a].[Id] = [p].[Id]",
                Sql);
        }

        public override void Include_address_shadow()
        {
            base.Include_address_shadow();

            Assert.Equal(
                @"SELECT [p].[Id], [p].[Name], [a].[Id], [a].[City], [a].[PersonId], [a].[Street]
FROM [Person2] AS [p]
LEFT JOIN [Address2] AS [a] ON [a].[PersonId] = [p].[Id]",
                Sql);
        }

        private readonly OneToOneQuerySqlCeFixture _fixture;

        public IncludeOneToOneSqlCeTest(OneToOneQuerySqlCeFixture fixture)
        {
            _fixture = fixture;
        }

        protected override DbContext CreateContext()
        {
            return _fixture.CreateContext();
        }

        private static string Sql
        {
            get { return TestSqlLoggerFactory.SqlStatements.Last(); }
        }
    }
}
