using System.ComponentModel.DataAnnotations;

namespace Buyurtma_ilovasi_2.Entities.Products;

public sealed class Product : BaseEntities
{
    [MaxLength(20)]
    public string Name { get; set; } = string.Empty;

    public long CatigoryId { get; set; }

    public string ImgPath { get; set; } = string.Empty;

}
