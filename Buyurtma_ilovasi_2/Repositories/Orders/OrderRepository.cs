using Buyurtma_ilovasi_2.Components;
using Buyurtma_ilovasi_2.Entities.orders;
using Buyurtma_ilovasi_2.Interface;
using Buyurtma_ilovasi_2.Interface.orders;
using Buyurtma_ilovasi_2.Utils;
using Buyurtma_ilovasi_2.ViewModels.Products;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace Buyurtma_ilovasi_2.Repositories.Orders;

internal class OrderRepository : BaseRepository, IOrderRepository
{
    public async Task<int> CreateAsync(Entities.orders.Order obj)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.orders(table_name, food_name, food_count, food_price)" +
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
        throw new System.NotImplementedException();
    }

    public Task<IList<Entities.orders.Order>> GetAllAsync(PagenationParams @params)
    {
        throw new System.NotImplementedException();
    }

    public Task<Entities.orders.Order> GetAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public Task<int> UpdateAsync(long obj, Entities.orders.Order editedObj)
    {
        throw new System.NotImplementedException();
    }

    public async Task<IList<Order>> GetAllByString(string table_name)

    {
        try
        {
            List<Order> list = new List<Order>();
            await _connection.OpenAsync();

            string query = $"select *from orders where table_name = '{table_name}'";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var orders = new Order();
                        orders.table_name = reader.GetString(0);
                        orders.food_name = reader.GetString(1);
                        orders.food_count = reader.GetInt32(2);
                        orders.food_price = reader.GetFloat(3);

                        list.Add(orders);
                    }
                }
            }
            return list;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return new List<Order>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> DeletedAsync(string table_name)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"DELETE FROM public.orders WHERE table_name = '{table_name}';";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                var res = await command.ExecuteNonQueryAsync();
                return res;
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
}
