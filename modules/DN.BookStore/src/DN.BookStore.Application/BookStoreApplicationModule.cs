using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;
using Volo.Abp.Threading;
using Volo.Abp.GlobalFeatures;

namespace DN.BookStore;

[DependsOn(
    typeof(BookStoreDomainModule),
    typeof(BookStoreApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class BookStoreApplicationModule : AbpModule
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        base.PreConfigureServices(context);

        OneTimeRunner.Run(() =>
        {
            GlobalFeatureManager.Instance.Enable("BookStore.Book");
            GlobalFeatureManager.Instance.Enable("BookStore.Author");
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {        
        context.Services.AddAutoMapperObjectMapper<BookStoreApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<BookStoreApplicationModule>(validate: true);
        });
    }
}
