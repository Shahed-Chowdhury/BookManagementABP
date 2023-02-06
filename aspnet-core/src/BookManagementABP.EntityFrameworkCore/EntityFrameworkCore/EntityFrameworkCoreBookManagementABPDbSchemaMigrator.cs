using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookManagementABP.Data;
using Volo.Abp.DependencyInjection;

namespace BookManagementABP.EntityFrameworkCore;

public class EntityFrameworkCoreBookManagementABPDbSchemaMigrator
    : IBookManagementABPDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreBookManagementABPDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the BookManagementABPDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<BookManagementABPDbContext>()
            .Database
            .MigrateAsync();
    }
}
