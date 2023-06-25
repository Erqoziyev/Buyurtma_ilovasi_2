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
    /// Interaction logic for KabobPage.xaml
    /// </summary>
    public partial class KabobPage : Page
    {
        private readonly ProductRepository _productRepository;

        public KabobPage()
        {
            InitializeComponent();
            this._productRepository = new ProductRepository();

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            wrpProduct.Children.Clear();
            var products = await _productRepository.Get("Kabob");

            foreach (var product in products)
            {
                MealAddUserControl mealAddUserControl = new MealAddUserControl();
                mealAddUserControl.SetData(product);
                wrpProduct.Children.Add(mealAddUserControl);
            }
        }
    }
}

