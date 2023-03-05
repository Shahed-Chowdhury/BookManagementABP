using BookManagementABP.Emailing;
using BookManagementABP.Emailing.Templates.ConfirmationEmail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BookManagementABP.Pages.Account
{
    public class CustomRegisterConfirmationModel: PageModel
    {
        public string EmailAddress { get; set; }
        private readonly EmailService _emailService;

        public CustomRegisterConfirmationModel(EmailService emailService)
        {
            _emailService = emailService;

        }
        //CustomRegisterConfirmationModel(EmailService emailService)
        //{
        //    _emailService= emailService;
        //}

        public async Task<IActionResult> OnGetAsync(string email, string returnUrl=null)
        {
            if(email == null)
            {
                return RedirectToPage("/Login");
            }
            var Input = new ConfirmationEmail();
            Input.Email = email;
            await _emailService.ConfirmationEmailAsync(Input);
            EmailAddress = email;
            return Page();
        }
    }
}
