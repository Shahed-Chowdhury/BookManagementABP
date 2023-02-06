using System.Threading.Tasks;

namespace BookManagementABP.Data;

public interface IBookManagementABPDbSchemaMigrator
{
    Task MigrateAsync();
}
