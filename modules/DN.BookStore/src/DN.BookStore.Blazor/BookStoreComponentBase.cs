using DN.BookStore.Localization;
using Volo.Abp.AspNetCore.Components;

namespace DN.BookStore.Blazor
{
    public abstract class BookStoreComponentBase : AbpComponentBase
    {
        protected BookStoreComponentBase()
        {
            LocalizationResource = typeof(BookStoreResource);
        }
    }
}
