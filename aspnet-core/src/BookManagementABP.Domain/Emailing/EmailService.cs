using BookManagementABP.Emailing.Templates.ConfirmationEmail;
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
    public class EmailService : ITransientDependency
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

        public async Task InvitedUserEmailAsync(InvitedUser input)
        {
            try
            {
                //var emailBody = await _templateRenderer.RenderAsync(StandardEmailTemplates.Message, new { message = "ABP Framework provides IEmailSender service that is used to send emails." });

                var emailBody = await _templateRenderer.RenderAsync(
                    CustomEmailTemplates.InvitedUser,
                    new InvitedUser()
                    {
                        FirstName = input.FirstName,
                        LastName = input.LastName,
                        Email = input.Email,
                        PhoneNumber = input.PhoneNumber,
                        UserId = input.UserId,
                    }

                );

                await _emailSender.SendAsync(input.Email, "Invitation from Shahed's BookManagement App", emailBody);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }

        }

        public async Task ConfirmationEmailAsync(ConfirmationEmail input)
        {
            try
            {
                var emailBody = await _templateRenderer.RenderAsync(
                    CustomEmailTemplates.ConfirmationEmail,
                    new ConfirmationEmail()
                    {
                        Email = input.Email
                    }

                );

                await _emailSender.SendAsync(input.Email, "Shahed's BookManagementABP", emailBody);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
        }
    }
}
