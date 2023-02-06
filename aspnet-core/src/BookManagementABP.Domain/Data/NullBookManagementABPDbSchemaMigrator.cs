using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace BookManagementABP.Data;

/* This is used if database provider does't define
 * IBookManagementABPDbSchemaMigrator implementation.
 */
public class NullBookManagementABPDbSchemaMigrator : IBookManagementABPDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
