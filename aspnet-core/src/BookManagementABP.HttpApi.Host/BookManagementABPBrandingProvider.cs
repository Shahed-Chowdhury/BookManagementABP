using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace BookManagementABP;

[Dependency(ReplaceServices = true)]
public class BookManagementABPBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "BookManagementABP";
}
