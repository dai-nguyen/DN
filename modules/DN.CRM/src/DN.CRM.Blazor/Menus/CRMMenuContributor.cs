using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace DN.CRM.Blazor.Menus;

public class CRMMenuContributor : IMenuContributor
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
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(CRMMenus.Prefix, displayName: "CRM", "/CRM", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
