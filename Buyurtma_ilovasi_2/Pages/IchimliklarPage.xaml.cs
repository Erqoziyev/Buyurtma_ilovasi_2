
using Buyurtma_ilovasi_2.Components;
using Buyurtma_ilovasi_2.Repositories.Products;
using System.Windows;
using System.Windows.Controls;

namespace Buyurtma_ilovasi_2.Pages;

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
