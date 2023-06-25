using Buyurtma_ilovasi_2.Constans;
using Npgsql;

namespace Buyurtma_ilovasi_2.Repositories;

public abstract class BaseRepository
{
    protected readonly NpgsqlConnection _connection;
    public BaseRepository()
    {
        _connection = new NpgsqlConnection(db_Constans.DB_CONNECTIONSTRIING); 
    }
}
