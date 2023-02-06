using System;
using System.Collections.Generic;
using System.Text;
using BookManagementABP.Localization;
using Volo.Abp.Application.Services;

namespace BookManagementABP;

/* Inherit your application services from this class.
 */
public abstract class BookManagementABPAppService : ApplicationService
{
    protected BookManagementABPAppService()
    {
        LocalizationResource = typeof(BookManagementABPResource);
    }
}
