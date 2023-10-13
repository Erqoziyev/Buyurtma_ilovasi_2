using Buyurtma_ilovasi_2.Entities;

namespace Buyurtma_ilovasi_2.ViewModels.Products
{
    public sealed class ProductViewModel : BaseEntities
    {
        public string MaxsulotTuri { get; set; } = string.Empty;
        public string MaxsulotNomi { get; set; } = string.Empty;
        public float MaxsulotNarxi { get; set; }
        public string MAxsulotRasmi { get; set; } = string.Empty;
    }
}
