using Volo.Abp.Settings;

namespace BookManagementABP.Settings;

public class BookManagementABPSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(BookManagementABPSettings.MySetting1));
    }
}
