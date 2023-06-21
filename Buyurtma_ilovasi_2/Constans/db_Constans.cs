namespace Buyurtma_ilovasi_2.Constans;

public class db_Constans
{
    public const string DB_HOST = "localhost";
    public const string DB_PORT = "5432";
    public const string DB_DATABASE = "restaurant_db";
    public const string DB_USER = "postgres";
    public const string DB_PASSWORD = "0809";

    public const string DB_CONNECTIONSTRIING =
                        $"Host={DB_HOST};" +
                        $"Port={DB_PORT};" +
                        $"Database={DB_DATABASE};" +
                        $"User Id={DB_USER};" +
                        $"Password={DB_PASSWORD};";            
}
