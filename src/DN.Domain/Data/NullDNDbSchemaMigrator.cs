using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace DN.Data;

/* This is used if database provider does't define
 * IDNDbSchemaMigrator implementation.
 */
public class NullDNDbSchemaMigrator : IDNDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
