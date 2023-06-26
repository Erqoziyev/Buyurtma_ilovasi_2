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
    /// Interaction logic for StolPage.xaml
    /// </summary>
    public partial class StolPage : Page
    {
        
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
        }


        public string lblstol = string.Empty;
        private void stol_1_Click(object sender, RoutedEventArgs e)
        {
            TaomlarPage taomlarPage = new TaomlarPage();
            btnTaomlar_Click = MainWindow.btnTaomlar_Click;
            btnTaomlar_Click();
            Button stolButton = (Button)sender;
            MainWindow.lbstolDrid.Content = stolButton.Content.ToString();
        }
    }
}
