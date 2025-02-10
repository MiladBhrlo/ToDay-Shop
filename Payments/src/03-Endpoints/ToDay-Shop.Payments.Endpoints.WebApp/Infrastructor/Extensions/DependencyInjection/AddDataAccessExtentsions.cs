﻿using System.Reflection;
using ToDay_Shop.Payments.Core.Contracts.Common.Data.Commands;
using ToDay_Shop.Payments.Core.Contracts.Common.Data.Queries;

namespace ToDay_Shop.Payments.Endpoints.WebApp.Infrastructor.Extensions.DependencyInjection;

public static class AddDataAccessExtentsions
{
    public static IServiceCollection AddApplicationDataAccess(this IServiceCollection services,
                                                        IEnumerable<Assembly> assembliesForSearch) =>
        services.AddRepositories(assembliesForSearch);

    public static IServiceCollection AddRepositories(this IServiceCollection services,
        IEnumerable<Assembly> assembliesForSearch) =>
        services.AddWithTransientLifetime(assembliesForSearch, typeof(ICommandRepository<>), typeof(IQueryRepository));

}