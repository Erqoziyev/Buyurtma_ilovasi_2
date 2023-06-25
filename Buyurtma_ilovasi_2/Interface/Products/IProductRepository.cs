using Buyurtma_ilovasi_2.Entities.Products;
using Buyurtma_ilovasi_2.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Buyurtma_ilovasi_2.Interface.Products;

public interface IProductRepository : IRepository<Product, ProductViewModel>
{
    public Task<IList<ProductViewModel>> Get(string maxsulot_turi);

}
