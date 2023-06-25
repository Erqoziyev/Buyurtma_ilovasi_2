using Buyurtma_ilovasi_2.Components;
using Buyurtma_ilovasi_2.Entities.Products;
using Buyurtma_ilovasi_2.Repositories.Products;
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

namespace Buyurtma_ilovasi_2.Pages
{
    /// <summary>
    /// Interaction logic for IchimliklarPage.xaml
    /// </summary>
    public partial class IchimliklarPage : Page
    {
        private readonly ProductRepository _productRepository;

        public IchimliklarPage()
        {
            InitializeComponent();
            this._productRepository = new ProductRepository();

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var products = await _productRepository.Get("Ichimlik");

            foreach (var product in products)
            {
                MealAddUserControl mealAddUserControl = new MealAddUserControl();
                mealAddUserControl.SetData(product);
                wrpProduct.Children.Add(mealAddUserControl);
            }
        }
    }
}
