using Volo.Abp.Modularity;

namespace BookManagementABP;

[DependsOn(
    typeof(BookManagementABPApplicationModule),
    typeof(BookManagementABPDomainTestModule)
    )]
public class BookManagementABPApplicationTestModule : AbpModule
{

}
