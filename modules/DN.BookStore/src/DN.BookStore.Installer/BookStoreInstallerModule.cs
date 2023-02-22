using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace DN.BookStore;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class BookStoreInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<BookStoreInstallerModule>();
        });
    }
}
