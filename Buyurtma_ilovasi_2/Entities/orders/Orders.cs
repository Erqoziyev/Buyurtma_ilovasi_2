
using Buyurtma_ilovasi_2.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Buyurtma_ilovasi_2.Entities.orders;

public class Orders : BaseEntities
{
    public string table_name  { get; set; } = string.Empty;
    public string food_name { get; set; } = string.Empty;
    public int food_count { get; set; }
    public float food_price { get; set; }
}
