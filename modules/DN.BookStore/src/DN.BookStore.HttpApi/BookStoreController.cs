using DN.BookStore.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace DN.BookStore;

public abstract class BookStoreController : AbpControllerBase
{
    protected BookStoreController()
    {
        LocalizationResource = typeof(BookStoreResource);
    }
}
