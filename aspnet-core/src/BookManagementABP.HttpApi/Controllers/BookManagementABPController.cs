using BookManagementABP.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace BookManagementABP.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BookManagementABPController : AbpControllerBase
{
    protected BookManagementABPController()
    {
        LocalizationResource = typeof(BookManagementABPResource);
    }
}
