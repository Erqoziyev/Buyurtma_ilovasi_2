using Buyurtma_ilovasi_2.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Buyurtma_ilovasi_2.Components
{
    /// <summary>
    /// Interaction logic for MealAddUserControl.xaml
    /// </summary>
    public partial class MealAddUserControl : UserControl
    {
        public MealAddUserControl()
        {
            InitializeComponent();
        }
        public void SetData(ProductViewModel productViewModel)
        {
            lblFoodName.Content = productViewModel.MaxsulotNomi;
            lblFoodPrice.Content = productViewModel.MaxsulotNarxi;
            ImgBrushMeal.ImageSource = new BitmapImage(new System.Uri(productViewModel.MAxsulotRasmi, UriKind.Relative));
        }

    }
}
