﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ToDay_Shop.Customers.Infrastructor.PostgreSql.Commands.Common.Extensions
{
    public static class RowVersionShadowProperty
    {
        public static readonly string RowVersion = nameof(RowVersion);

        public static void AddRowVersionShadowProperty<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : class
            => builder.Property<byte[]>(RowVersion).IsRowVersion();
    }
}
