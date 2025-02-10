﻿using Microsoft.EntityFrameworkCore.Diagnostics;
using ToDay_Shop.Payments.Infrastructor.Data.PostgreSql.Commands.Common.Extensions;

namespace ToDay_Shop.Payments.Infrastructor.Data.PostgreSql.Commands.Common.Interceptors;

public class AddAuditDataInterceptor : SaveChangesInterceptor
{

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        AddShadowProperties(eventData);
        return base.SavingChanges(eventData, result);
    }


    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
                                                                          InterceptionResult<int> result,
                                                                          CancellationToken cancellationToken = default)
    {
        AddShadowProperties(eventData);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }


    private static void AddShadowProperties(DbContextEventData eventData)
    {
        var changeTracker = eventData.Context.ChangeTracker;
        changeTracker.SetAuditableEntityPropertyValues();
    }
}
