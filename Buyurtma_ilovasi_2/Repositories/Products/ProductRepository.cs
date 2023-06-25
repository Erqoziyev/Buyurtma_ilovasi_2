using Buyurtma_ilovasi_2.Entities.Products;
using Buyurtma_ilovasi_2.Interface.Products;
using Buyurtma_ilovasi_2.Utils;
using Buyurtma_ilovasi_2.ViewModels.Products;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Buyurtma_ilovasi_2.Repositories.Products
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public async Task<int> CreateAsync(Product obj)
        {
            try
            {
                await _connection.OpenAsync();
                string query = "INSERT INTO public.products(catigory_id, name, price, img_path)" +
                               "VALUES (@catigory_id, @name, @price, @img_path);";

                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("catigory_id", obj.CatigoryId);
                    command.Parameters.AddWithValue("name", obj.Name);
                    command.Parameters.AddWithValue("price", obj.Price);
                    command.Parameters.AddWithValue("img_path", obj.ImgPath);

                    var result = await command.ExecuteNonQueryAsync();
                    return result;
                } 
                
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public Task<int> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ProductViewModel>> Get(string maxsulot_turi)
        {
            try
            {
                List<ProductViewModel> list = new List<ProductViewModel>();
                await _connection.OpenAsync();

                string query = $"select *from products_view where maxsulot_turi = '{maxsulot_turi}'";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var product = new ProductViewModel();
                            product.Id = reader.GetInt64(0);
                            product.MaxsulotTuri = reader.GetString(1);
                            product.MaxsulotNomi = reader.GetString(2);
                            product.MaxsulotNarxi = reader.GetFloat(3);
                            product.MAxsulotRasmi = reader.GetString(4);

                            list.Add(product);
                        }
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<ProductViewModel>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<IList<ProductViewModel>> GetAllAsync(PagenationParams @params)
        {
            
            throw new NotImplementedException();
        }

        public Task<ProductViewModel> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ProductViewModel>> GetByDateAsync(long maxsulot_turi)
        {
            throw new NotImplementedException();

        }

        public Task<int> UpdateAsync(long obj, Product editedObj)
        {
            throw new NotImplementedException();
        }
    }
}
