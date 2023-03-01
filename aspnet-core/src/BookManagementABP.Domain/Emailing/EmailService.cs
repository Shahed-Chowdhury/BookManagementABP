using BookManagementABP.Emailing.Templates.InvitedUser;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Emailing;
using Volo.Abp.Emailing.Templates;
using Volo.Abp.TextTemplating;

namespace BookManagementABP.Emailing
{
    public class EmailService: ITransientDependency
    {
        private readonly IEmailSender _emailSender;
        private readonly ITemplateRenderer _templateRenderer;
        private readonly IConfiguration _configuration;

        public EmailService(IEmailSender emailSender, ITemplateRenderer templateRenderer, IConfiguration configuration)
        {
            _emailSender = emailSender;
            _templateRenderer = templateRenderer;
            _configuration = configuration;
        }

        public async Task InvitedUserEmailAsync(string email)
        {
            try
            {
                //var emailBody = await _templateRenderer.RenderAsync(StandardEmailTemplates.Message, new { message = "ABP Framework provides IEmailSender service that is used to send emails." });

                var emailBody = await _templateRenderer.RenderAsync(
                    CustomEmailTemplates.InvitedUser
                );

                await _emailSender.SendAsync(
                    email,
                    "Invited User",
                    emailBody
                );
            }
            catch(Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
            
        }
    }
}
