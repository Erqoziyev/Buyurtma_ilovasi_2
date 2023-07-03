using Buyurtma_ilovasi_2.Components;
using Buyurtma_ilovasi_2.Constans;
using Buyurtma_ilovasi_2.Entities.orders;
using Buyurtma_ilovasi_2.Interface.orders;
using Buyurtma_ilovasi_2.Pages;
using Buyurtma_ilovasi_2.Repositories;
using Buyurtma_ilovasi_2.Repositories.Orders;
using Buyurtma_ilovasi_2.Repositories.Tables;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
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
using static Buyurtma_ilovasi_2.Components.MealAddUserControl;

namespace Buyurtma_ilovasi_2;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public List<OrderedMealUserControl> list = new List<OrderedMealUserControl>();

    List<Order> ord = new List<Order>();

    private readonly TableRepository _tableRepository;


    public Action<String> DeleteOrders { get; set; }


    protected readonly NpgsqlConnection _connection;

    private readonly IOrderRepository _orderRepository;

    public bool ischeck = false;

    public MainWindow()
    {
        InitializeComponent();
        _connection = new NpgsqlConnection(db_Constans.DB_CONNECTIONSTRIING);
        this._orderRepository = new OrderRepository();
        this._tableRepository = new TableRepository();
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void btnMaximize_Click(object sender, RoutedEventArgs e)
    {
        if (this.WindowState == WindowState.Maximized)
            this.WindowState = WindowState.Normal;
        else this.WindowState = WindowState.Maximized;
    }

    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }

    private void borderDragable_MouseDown(object sender, MouseButtonEventArgs e)
    {
        this.DragMove();
    }

    public void btnBosh_stollar_Click(object sender, RoutedEventArgs e)
    {
        StolPage stolPage = new StolPage(this);
        PageNavigator.Content = null;
        PageNavigator.Content = stolPage;
    }

    private void btnIchimliklar_Click(object sender, RoutedEventArgs e)
    {
        IchimliklarPage ichimliklarPage = new IchimliklarPage();
        PageNavigator.Content = ichimliklarPage;
    }

    private void btnSalatlar_Click(object sender, RoutedEventArgs e)
    {
        SalatlarPage salatlarPage = new SalatlarPage();
        PageNavigator.Content = salatlarPage;
    }

    private void btnShirinliklar_Click(object sender, RoutedEventArgs e)
    {
        ShirinliklarPage shirinliklarPage = new ShirinliklarPage();
        PageNavigator.Content = shirinliklarPage;
    }
    private void btnSozlamalar_Click(object sender, RoutedEventArgs e)
    {
        SozlamalarPage sozlamalarPage = new SozlamalarPage();
        PageNavigator.Content = sozlamalarPage;
    }

    private void btnOlib_ketish_Click(object sender, RoutedEventArgs e)
    {
        TaomlarPage taomlarPage = new TaomlarPage();
        PageNavigator.Content = taomlarPage;
        lbstolDrid.Content = rbOlib_ketish.Content.ToString();
    }

    private void btnKaboblar_Click(object sender, RoutedEventArgs e)
    {
        KabobPage sozlamalarPage = new KabobPage();
        PageNavigator.Content = sozlamalarPage;
    }

    private void btnTaomlar_Click(object sender, RoutedEventArgs e)
    {
        TaomlarPage taomlarPage = new TaomlarPage();
        PageNavigator.Content = taomlarPage;
    }

    public void btnTaomlar_Click()
    {
        TaomlarPage taomlarPage = new TaomlarPage();
        PageNavigator.Content = taomlarPage;
    }

    public float summa = 0;
    private async void btnXarid_qilish_Click(object sender, RoutedEventArgs e)
    {
        if (lbstolDrid.Content != "" && ord.Count > 0)
        {
            string name = lbstolDrid.Content.ToString();
            try
            {

                await _connection.OpenAsync();
                foreach (var obj in ord)
                {
                    obj.table_name = name;
                    string query = "INSERT INTO public.orders(table_name, food_name, food_count, food_price)" +
                                  "VALUES (@table_name, @food_name, @food_count, @food_price);";

                    await using (var command = new NpgsqlCommand(query, _connection))
                    {
                        command.Parameters.AddWithValue("table_name", obj.table_name);
                        command.Parameters.AddWithValue("food_name", obj.food_name);
                        command.Parameters.AddWithValue("food_count", obj.food_count);
                        command.Parameters.AddWithValue("food_price", obj.food_price);

                        var result = await command.ExecuteNonQueryAsync();
                    }
                    summa += obj.food_price;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                await _connection.CloseAsync();
            }


            MessageBox.Show($"Siz {summa} so'mlik maxsulot xarid qildingiz. Buyurtmangiz tayyorlanmoqda!");
            stpOrders.Children.Clear();
            lbstolDrid.Content = "";
            ischeck = true;

            await _tableRepository.UpdatedAsync(name);
            
            StolPage stolPage = new StolPage(this);
            
            PageNavigator.Content = stolPage;

        }
        else
        {
            MessageBox.Show("Hali stol yoki maxsulot tanlamadingiz!");
            StolPage stolPage = new StolPage(this);
            PageNavigator.Content = stolPage;
        }

    }

    private void btnBekor_qilish(object sender, RoutedEventArgs e)
    {
        list.Clear();
        stpOrders.Children.Clear();
        lbstolDrid.Content = "";
        StolPage stolPage = new StolPage(this);
        PageNavigator.Content = stolPage;
    }


    private void Load(object sender, RoutedEventArgs e)
    {

    }

    public async Task RefreshAsync(Order order)
    {
        ord.Add(order);
        OrderedMealUserControl orderedMealUserControl = new OrderedMealUserControl();
        orderedMealUserControl.SetData(order);
        orderedMealUserControl.DeleteOrder = RemoveOrder;
        list.Add(orderedMealUserControl);
        stpOrders.Children.Add(orderedMealUserControl);
        
    }



    public void RemoveOrder(Order orders)
    {
        for(int i=0; i<list.Count; i++)
        {
            if (list[i].lblName.Content.ToString() == orders.food_name)
            {
                stpOrders.Children.Remove(list[i]);
                ord.Remove(ord[i]);
                DeleteOrders(list[i].lblName.Content.ToString());
            }
        }
    }
}