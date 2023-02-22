using System.Threading.Tasks;

namespace DN.Data;

public interface IDNDbSchemaMigrator
{
    Task MigrateAsync();
}
