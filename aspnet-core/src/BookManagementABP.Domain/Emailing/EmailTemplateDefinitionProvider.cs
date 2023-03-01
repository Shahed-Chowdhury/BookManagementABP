using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.TextTemplating;

namespace BookManagementABP.Emailing
{
    public class EmailTemplateDefinitionProvider: TemplateDefinitionProvider, ITransientDependency
    {
        public override void Define(ITemplateDefinitionContext context)
        {
            context.Add(new TemplateDefinition(
                name: CustomEmailTemplates.InvitedUser
            ).WithVirtualFilePath("/Emailing/Templates/InvitedUser/InvitedUser.html", isInlineLocalized: true));
        }
    }
}
