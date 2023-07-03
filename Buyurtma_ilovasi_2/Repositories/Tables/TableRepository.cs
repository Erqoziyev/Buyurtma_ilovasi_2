using Buyurtma_ilovasi_2.Entities.orders;
using Buyurtma_ilovasi_2.Entities.Tables;
using Buyurtma_ilovasi_2.Interface.Tables;
using Buyurtma_ilovasi_2.Utils;
using Buyurtma_ilovasi_2.ViewModels.Products;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace Buyurtma_ilovasi_2.Repositories.Tables;

internal class TableRepository : BaseRepository, ITableRepository
{
    public Task<int> CreateAsync(Tablle obj)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<Tablle>> GetAllAsync(PagenationParams @params)
    {
        try
        {
            List<Tablle> list = new List<Tablle>();
            await _connection.OpenAsync();

            string query = $"select * from tables order by id desc " +
                            $"offset {(@params.PageNumber - 1) * @params.PageSize} " +
                            $"limit {@params.PageSize}";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var table = new Tablle();
                        table.Id = reader.GetInt64(0);
                        table.table_name = reader.GetString(1);
                        table.is_empty = reader.GetBoolean(2);

                        list.Add(table);
                    }
                }
            }

            

            return list;

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return new List<Tablle>();
        }
        finally
        {
            await _connection.CloseAsync();

        }
    }

    public Task<Tablle> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> GetByAsync(string table_name)
    {
        try
        {
            await _connection.OpenAsync();
            bool is_empty = false;
            string query = $"select is_empty from tables where name = '{table_name}'";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        is_empty = reader.GetBoolean(0);
                    }
                }
            }
            return is_empty;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return true;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<int> UpdateAsync(long obj, Tablle editedObj)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdatedAsync(string table_name)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"UPDATE public.tables SET is_empty = false WHERE name = '{table_name}';";
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
