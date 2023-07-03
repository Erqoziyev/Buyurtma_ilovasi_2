using Buyurtma_ilovasi_2.Components;
using Buyurtma_ilovasi_2.Repositories.Orders;
using Buyurtma_ilovasi_2.Repositories.Tables;
using Buyurtma_ilovasi_2.Utils;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Buyurtma_ilovasi_2.Pages
{
    /// <summary>
    /// Interaction logic for StolPage.xaml
    /// </summary>
    public partial class StolPage : Page
    {

        private readonly OrderRepository _orderRepository;

        private readonly TableRepository _tableRepository;

        TaomlarPage taomlarPage = new TaomlarPage();

        public Action btnTaomlar_Click { get; set; }
        public MainWindow MainWindow { get; set; }

        public StolPage()
        {
            InitializeComponent();
        }
        public StolPage(MainWindow mainWindow)
        {
            InitializeComponent();
            MainWindow = mainWindow;
            this._orderRepository = new OrderRepository();
            this._tableRepository = new TableRepository();  
        }


        public string lblstol = string.Empty;

        private async void stol_1_Click(object sender, RoutedEventArgs e)
        {
            TaomlarPage taomlarPage = new TaomlarPage();
            PeymentPage page = new PeymentPage();
            Button stolButton = (Button)sender;

            string str = stolButton.Content.ToString();
            page.table_name = stolButton.Content.ToString();

            bool is_empty =await _tableRepository.GetByAsync(str);

            if (!is_empty)
            {
                MessageBoxResult result = MessageBox.Show("Hisobni to'lash", "Davom etish",
                                                            MessageBoxButton.YesNo, MessageBoxImage.None,
                                                            MessageBoxResult.Yes, MessageBoxOptions.DefaultDesktopOnly);

                if (result == MessageBoxResult.Yes)
                {
                    MainWindow.PageNavigator.Content = page;
                }
                else
                {
                    btnTaomlar_Click = MainWindow.btnTaomlar_Click;
                    btnTaomlar_Click();

                    MainWindow.stpOrders.Children.Clear();
                    MainWindow.rbBosh_stollar.IsChecked = false;
                    MainWindow.rbTaomlar.IsChecked = true;
                }
                var orders = await _orderRepository.GetAllByString(str);

                foreach (var order in orders)
                {
                    page.summa += order.food_price;
                    OrderedMealUserControl orderedMealUserControl = new OrderedMealUserControl();
                    orderedMealUserControl.SetData(order);
                    orderedMealUserControl.btndelete.IsEnabled = false;
                    page.stpOrdered.Children.Add(orderedMealUserControl);
                }
            }
            else
            {
                btnTaomlar_Click = MainWindow.btnTaomlar_Click;
                btnTaomlar_Click();

                MainWindow.lbstolDrid.Content = stolButton.Content.ToString();

                MainWindow.stpOrders.Children.Clear();
                MainWindow.rbBosh_stollar.IsChecked = false;
                MainWindow.rbTaomlar.IsChecked = true;
            }

        } 
        
        private async void Yaxshimisz_load(object sender, RoutedEventArgs e)
        {
            var paginationParams = new PagenationParams()
            {
                PageNumber = 1,
                PageSize = 50
            };
            
            var tables = await _tableRepository.GetAllAsync(paginationParams);
            foreach (var table in tables)
            {
                if (table.is_empty == false)
                {
                    string name_table = table.table_name.ToString()!;

                    if (stol_1.Content.ToString() == name_table)
                        this.stol_1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E9CD99"));
                    else if (stol_2.Content.ToString() == name_table)
                        this.stol_2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E9CD99"));
                    else if (stol_3.Content.ToString() == name_table)
                        this.stol_3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E9CD99"));
                    else if (stol_4.Content.ToString() == name_table)
                        this.stol_4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E9CD99"));
                    else if (stol_5.Content.ToString() == name_table)
                        this.stol_5.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E9CD99"));
                    else if (stol_6.Content.ToString() == name_table)
                        this.stol_6.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E9CD99"));
                    else if (stol_7.Content.ToString() == name_table)
                        this.stol_7.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E9CD99"));
                    else if (stol_8.Content.ToString() == name_table)
                        this.stol_8.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E9CD99"));
                    else if(stol_9.Content.ToString() == name_table)
                        this.stol_9.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E9CD99"));
                }
            }
        }
    }
}
