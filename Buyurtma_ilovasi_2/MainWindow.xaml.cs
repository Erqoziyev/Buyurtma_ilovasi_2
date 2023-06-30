using Buyurtma_ilovasi_2.Entities.orders;
using Buyurtma_ilovasi_2.Interface.orders;
using Buyurtma_ilovasi_2.Pages;
using Buyurtma_ilovasi_2.Repositories.Orders;
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
using static Buyurtma_ilovasi_2.Components.MealAddUserControl;

namespace Buyurtma_ilovasi_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly IOrderRepository _orderRepository;

        public MainWindow()
        {
            InitializeComponent();
            this._orderRepository = new OrderRepository();
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

        private void Load(object sender, RoutedEventArgs e)
        {

        }
        public void AddDataToDataGrid(AddValue addValue)
        {
            DtgMaxsulot.Items.Add(addValue);
        }

        public float summa = 0;
        private async void btnXarid_qilish_Click(object sender, RoutedEventArgs e)
        {
            Orders orders = new Orders();
            if (DtgMaxsulot.Items.Count > 0 )
            {
                if (lbstolDrid.Content != "")
                {
                    AddValue addValue = new AddValue();
                    orders.table_name = lbstolDrid.Content.ToString();
                    foreach (var item in DtgMaxsulot.Items)
                    {
                        addValue = item as AddValue;
                        orders.food_name= addValue.TaomNomi.ToString();
                        orders.food_count= addValue.Soni;
                        orders.food_price= addValue.Narxi;

                        var result = await _orderRepository.CreateAsync(orders);
                    }

                    MessageBox.Show($"Siz {summa} ming so'mlik maxsulot xarid qildingiz!");
                    StolPage stolPage = new StolPage(this);
                    PageNavigator.Content = stolPage;
                }
                else
                {
                    MessageBox.Show("Stol tanlanmagan!");
                    StolPage stolPage = new StolPage(this);
                    PageNavigator.Content = stolPage;
                }
            }
            else
                MessageBox.Show("Hali hech narsa xarid qilmadingiz!");
        }

        private void btnBekor_qilish(object sender, RoutedEventArgs e)
        {
            DtgMaxsulot.Items.Clear();
        }

        private void btnDelete(object sender, RoutedEventArgs e)
        {
            if (DtgMaxsulot.SelectedItems.Count > 0)
            {

                AddValue addValue = new AddValue();
                foreach (var obj in DtgMaxsulot.SelectedItems)
                {
                    addValue = obj as AddValue;
                    DtgMaxsulot.Items.Remove(addValue);
                    break;
                }
            }
        }
    }
}