using DN.BookStore.Localization;
using Volo.Abp.Application.Services;

namespace DN.BookStore;

public abstract class BookStoreAppService : ApplicationService
{
    protected BookStoreAppService()
    {
        LocalizationResource = typeof(BookStoreResource);
        ObjectMapperContext = typeof(BookStoreApplicationModule);
    }
}
