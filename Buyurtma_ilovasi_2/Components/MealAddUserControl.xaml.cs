using Buyurtma_ilovasi_2.Entities.orders;
using Buyurtma_ilovasi_2.Interface.orders;
using Buyurtma_ilovasi_2.Pages;
using Buyurtma_ilovasi_2.Repositories.Orders;
using Buyurtma_ilovasi_2.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Buyurtma_ilovasi_2.Components;

/// <summary>
/// Interaction logic for MealAddUserControl.xaml
/// </summary>
public partial class MealAddUserControl : UserControl
{

    List<OrderedMealUserControl> lists = new List<OrderedMealUserControl>();

    public int count { get; set; }
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

    private void btnXarid_qilish_Click(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = GetMainWindow();
        lists = mainWindow.list;
        mainWindow.DeleteOrders = DeleteOrder;
        Order orders = new Order();

        if (lists.Count > 0)
        {
            bool chack = true;
            for (var i=0; i<lists.Count; i++)
            {
                if (lblFoodName.Content.ToString() == lists[i].lblName.Content.ToString())
                {
                    chack = false;
                }
                
                    
            }

            if (chack)
            {
                int sum = Convert.ToInt32(tbCount.Text) * Convert.ToInt32(lblFoodPrice.Content.ToString());
                orders.food_price = sum;
                orders.food_name = lblFoodName.Content.ToString();
                orders.food_count = int.Parse(tbCount.Text.ToString());
                mainWindow.RefreshAsync(orders);
            }
            else
            {
                MessageBox.Show("Kechirasiz bu maxsulot belgilangan. Qayta tanlash uchun ro'yxatdan o'chiring!");
            }



        }
        else
        {
            int sum = Convert.ToInt32(tbCount.Text) * Convert.ToInt32(lblFoodPrice.Content.ToString());
            orders.food_price = sum;
            orders.food_name = lblFoodName.Content.ToString();
            orders.food_count = int.Parse(tbCount.Text.ToString());
            mainWindow.RefreshAsync(orders);
        }
    }
    public void DeleteOrder(string food_name)
    {
        for (int i = 0; i < lists.Count; i++)
        {
            if (lists[i].lblName.Content.ToString() == food_name)
            {
                lists.RemoveAt(i);
            }
        }
    }

    public static MainWindow GetMainWindow()
    {
        MainWindow mainWindow = null;

        foreach (Window window in Application.Current.Windows)
        {
            Type type = typeof(MainWindow);
            if (window != null && window.DependencyObjectType.Name == type.Name)
            {
                mainWindow = (MainWindow)window;
                if (mainWindow != null)
                {
                    break;
                }
            }
        }
        return mainWindow;

    }

    private void btnMinus_Click(object sender, RoutedEventArgs e)
    {
        if(count > 1)
        {
            count--;
        }
        tbCount.Text = count.ToString();
    }

    private void btnPlus_Click(object sender, RoutedEventArgs e)
    {
        count++;
        tbCount.Text = count.ToString();
    }
}
