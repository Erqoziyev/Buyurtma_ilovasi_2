using Buyurtma_ilovasi_2.Repositories.Orders;
using Buyurtma_ilovasi_2.Repositories.Tables;
using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Buyurtma_ilovasi_2.Pages;

/// <summary>
/// Interaction logic for PeymentPage.xaml
/// </summary>
public partial class PeymentPage : Page
{
    public MainWindow MainWindow { get; set; }


    private readonly OrderRepository _orderRepository;

    private readonly TableRepository _tableRepository;

    public float summa = 0;

    public string table_name = string.Empty;

    public PeymentPage()
    {
        InitializeComponent();
        this._orderRepository = new OrderRepository();
        this._tableRepository = new TableRepository();
    }
    public PeymentPage(MainWindow mainWindow)
    {
        InitializeComponent();
        MainWindow = mainWindow;
        this._orderRepository = new OrderRepository();
        this._tableRepository = new TableRepository();
    }

    private void tbMaxsulotNarxi_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        string text = textBox.Text;
        string filteredText = Regex.Replace(text, "[^0-9]+", "");

        if (text != filteredText)
        {
            int caretIndex = textBox.CaretIndex;
            textBox.Text = filteredText;
            textBox.CaretIndex = caretIndex > 0 ? caretIndex - 1 : 0;
        }
    }

    private async void btnTolash_Click(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = GetMainWindow();

        float a = float.Parse(tbMaxsulotNarxi.Text.ToString());
        if (summa == a)
        {
            MessageBox.Show("To'lov o'tdi. Tashrifingiz uchun rahmat! ");
            var result = await _tableRepository.UpdatedTrueAsync(table_name);
            var res = await _orderRepository.DeletedAsync(table_name);
            StolPage stolPage = new StolPage();
            mainWindow.PageNavigator.Content = stolPage;
            mainWindow.list.Clear();
            mainWindow.stpOrders.Children.Clear();
            mainWindow.ord.Clear();
            mainWindow.lbstolDrid.Content = "";
            summa = 0;
        }
        else
        {
            MessageBox.Show("Summani tekshirib qaytadan kiriting!");
            tbMaxsulotNarxi.Text = string.Empty;
        }
    }

    private void Loading(object sender, RoutedEventArgs e)
    {
        lblsom.Content = summa;
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
}
