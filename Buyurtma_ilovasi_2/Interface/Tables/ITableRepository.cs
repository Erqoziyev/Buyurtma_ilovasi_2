using Buyurtma_ilovasi_2.Entities.Tables;
using Buyurtma_ilovasi_2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Buyurtma_ilovasi_2.Interface.Tables;

 interface ITableRepository : IRepository<Tablle, Tablle>
{
    public Task<int> UpdatedFalseAsync(string table_name);

    public Task<int> UpdatedTrueAsync(string table_name);

    public Task<bool> GetByAsync(string table_name);


}
