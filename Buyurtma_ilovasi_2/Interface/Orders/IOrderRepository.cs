using Buyurtma_ilovasi_2.Entities.orders;
using Buyurtma_ilovasi_2.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buyurtma_ilovasi_2.Interface.orders;

public interface IOrderRepository : IRepository<Orders, Orders>
{
    Task GetAllAsync(Orders orders);
    public void getname(string name);
}
