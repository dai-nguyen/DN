using DN.BookStore.Localization;
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

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<BookStoreResource>();

        if (GlobalFeatureManager.Instance.IsEnabled("BookStore.Book")
            && GlobalFeatureManager.Instance.IsEnabled("BookStore.Author"))
        {
            //Add main menu items.
            context.Menu.AddItem(
                new ApplicationMenuItem(
                    BookStoreMenus.Prefix,
                    displayName: "Book Store",
                    icon: "fa fa-book")
                .AddItem(
                    new ApplicationMenuItem(
                        "BooksStore.Books",
                        l["Menu:Books"],
                        url: "/books"
                    )
                )
                .AddItem(
                    new ApplicationMenuItem(
                    "BooksStore.Authors",
                    l["Menu:Authors"],
                    url: "/authors"
                )));
        }
        
        return Task.CompletedTask;
    }
}
