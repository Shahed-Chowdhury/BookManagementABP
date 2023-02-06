using BookManagementABP.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace BookManagementABP;

[DependsOn(
    typeof(BookManagementABPEntityFrameworkCoreTestModule)
    )]
public class BookManagementABPDomainTestModule : AbpModule
{

}
