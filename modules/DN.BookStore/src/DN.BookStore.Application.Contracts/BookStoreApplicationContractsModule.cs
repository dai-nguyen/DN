﻿using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;
using Volo.Abp.Threading;

namespace DN.BookStore;

[DependsOn(
    typeof(BookStoreDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class BookStoreApplicationContractsModule : AbpModule
{
    
}
