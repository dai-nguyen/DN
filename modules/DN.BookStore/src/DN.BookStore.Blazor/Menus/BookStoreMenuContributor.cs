using DN.BookStore.Localization;
using System.Threading.Tasks;
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

        //Add main menu items.
        //context.Menu.AddItem(
        //    new ApplicationMenuItem(BookStoreMenus.Prefix, displayName: "BookStore", "/BookStore", icon: "fa fa-globe"));

        context.Menu.AddItem(
                new ApplicationMenuItem(
                    "BooksStore.Books",
                    l["Menu:Books"],
                    url: "/books",
                    icon: "fa fa-book"
                )
            );

        context.Menu.AddItem(
        new ApplicationMenuItem(
            "BooksStore.Authors",
            l["Menu:Authors"],
            url: "/authors"            
        )
    );

        //context.Menu.AddItem(
        //    new ApplicationMenuItem(
        //        "BooksStore",
        //        l["Menu:BookStore"],
        //        icon: "fa fa-book"
        //    ).AddItem(
        //        new ApplicationMenuItem(
        //            "BooksStore.Books",
        //            l["Menu:Books"],
        //            url: "/books"
        //        )
        //    )
        //);

        return Task.CompletedTask;
    }
}
