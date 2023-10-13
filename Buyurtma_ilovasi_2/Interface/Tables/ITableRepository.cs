using Buyurtma_ilovasi_2.Entities.Tables;
using System.Threading.Tasks;

namespace Buyurtma_ilovasi_2.Interface.Tables;

interface ITableRepository : IRepository<Tablle, Tablle>
{
    public Task<int> UpdatedFalseAsync(string table_name);

    public Task<int> UpdatedTrueAsync(string table_name);

    public Task<bool> GetByAsync(string table_name);


}
