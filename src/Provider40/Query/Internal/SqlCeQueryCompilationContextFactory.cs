﻿using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;
using Microsoft.EntityFrameworkCore.Utilities;
using Remotion.Linq.Parsing.Structure.NodeTypeProviders;

namespace Microsoft.EntityFrameworkCore.Query.Internal
{
    public class SqlCeQueryCompilationContextFactory : RelationalQueryCompilationContextFactory
    {
        public SqlCeQueryCompilationContextFactory(
                    [NotNull] IModel model,
                    [NotNull] ISensitiveDataLogger<SqlCeQueryCompilationContextFactory> logger,
                    [NotNull] IEntityQueryModelVisitorFactory entityQueryModelVisitorFactory,
                    [NotNull] IRequiresMaterializationExpressionVisitorFactory requiresMaterializationExpressionVisitorFactory,
                    [NotNull] MethodInfoBasedNodeTypeRegistry methodInfoBasedNodeTypeRegistry,
                    [NotNull] ICurrentDbContext currentContext)
            : base(
                Check.NotNull(model, nameof(model)),
                Check.NotNull(logger, nameof(logger)),
                Check.NotNull(entityQueryModelVisitorFactory, nameof(entityQueryModelVisitorFactory)),
                Check.NotNull(requiresMaterializationExpressionVisitorFactory, nameof(requiresMaterializationExpressionVisitorFactory)),
                Check.NotNull(methodInfoBasedNodeTypeRegistry, nameof(methodInfoBasedNodeTypeRegistry)),
                Check.NotNull(currentContext, nameof(currentContext)))
        {
        }


        public override QueryCompilationContext Create(bool async)
            => async
                ? new SqlCeQueryCompilationContext(
                    Model,
                    (ISensitiveDataLogger)Logger,
                    EntityQueryModelVisitorFactory,
                    RequiresMaterializationExpressionVisitorFactory,
                    new AsyncLinqOperatorProvider(),
                    new AsyncQueryMethodProvider(),
                    ContextType,
                    TrackQueryResults)
                : new SqlCeQueryCompilationContext(
                    Model,
                    (ISensitiveDataLogger)Logger,
                    EntityQueryModelVisitorFactory,
                    RequiresMaterializationExpressionVisitorFactory,
                    new LinqOperatorProvider(),
                    new QueryMethodProvider(),
                    ContextType,
                    TrackQueryResults);
    }
}
