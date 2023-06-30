using Buyurtma_ilovasi_2.Interface.orders;
using Buyurtma_ilovasi_2.Utils;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Buyurtma_ilovasi_2.Repositories.Orders;

public class OrderRepository : BaseRepository, IOrderRepository
{
    public async Task<int> CreateAsync(Entities.orders.Orders obj)
    {
        try
        {
            await _connection.OpenAsync();
            string query =  "INSERT INTO public.orders(table_name, food_name, food_count, food_price)" +
                            "VALUES (@table_name, @food_name, @food_count, @food_price);";

            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("table_name", obj.table_name);
                command.Parameters.AddWithValue("food_name", obj.food_name);
                command.Parameters.AddWithValue("food_count", obj.food_count);
                command.Parameters.AddWithValue("food_price", obj.food_price);

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

    public Task<IList<Entities.orders.Orders>> GetAllAsync(PagenationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task GetAllAsync(Entities.orders.Orders orders)
    {
        throw new NotImplementedException();
    }

    public Task<Entities.orders.Orders> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public void getname(string name)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long obj, Entities.orders.Orders editedObj)
    {
        throw new NotImplementedException();
    }
}
