﻿using System.Collections.Generic;

namespace Microsoft.EntityFrameworkCore.Query.ExpressionTranslators.Internal
{
    public class SqlCeCompositeMemberTranslator : RelationalCompositeMemberTranslator
    {
        public SqlCeCompositeMemberTranslator()
        {
            var sqlCeTranslators = new List<IMemberTranslator>
            {
                new SqlCeStringLengthTranslator(),
                new SqlCeDateTimeNowTranslator(),
                new SqlCeDateTimeDatePartComponentTranslator(),
            };

            // ReSharper disable once VirtualMemberCallInContructor
            AddTranslators(sqlCeTranslators);
        }
    }
}
