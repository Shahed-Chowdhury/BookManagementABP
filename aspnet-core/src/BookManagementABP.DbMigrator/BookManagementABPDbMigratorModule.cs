using BookManagementABP.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace BookManagementABP.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BookManagementABPEntityFrameworkCoreModule),
    typeof(BookManagementABPApplicationContractsModule)
    )]
public class BookManagementABPDbMigratorModule : AbpModule
{

}
