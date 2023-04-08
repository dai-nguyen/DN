using DN.BookStore.Localization;
using DN.BookStore.Permissions;
using System.Threading.Tasks;
using Volo.Abp.GlobalFeatures;
using Volo.Abp.UI.Navigation;

namespace DN.BookStore.Blazor.Menus;

public class BookStoreMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<BookStoreResource>();

        if (GlobalFeatureManager.Instance.IsEnabled("BookStore.Book")
            && GlobalFeatureManager.Instance.IsEnabled("BookStore.Author"))
        {
            var bookStoreMenu = context.Menu.AddItem(
                new ApplicationMenuItem(
                    BookStoreMenus.Prefix,
                    displayName: "Book Store",
                    icon: "fa fa-book"));

            if (await context.IsGrantedAsync(BookStorePermissions.Books.Default))
            {
                bookStoreMenu
                    .AddItem(
                        new ApplicationMenuItem(
                            "BooksStore.Books",
                            l["Menu:Books"],
                            url: "/books"
                        )
                    );
            }

            if (await context.IsGrantedAsync(BookStorePermissions.Authors.Default))
            {
                bookStoreMenu
                    .AddItem(
                        new ApplicationMenuItem(
                        "BooksStore.Authors",
                        l["Menu:Authors"],
                        url: "/authors"
                ));
            }   
        }        
    }
}
