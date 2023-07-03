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
    /// Interaction logic for ChoosePage.xaml
    /// </summary>
    public partial class ChoosePage : Page
    {
        public MainWindow MainWindow { get; set; }

        public ChoosePage()
        {
            InitializeComponent();
        }
        public ChoosePage(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
            InitializeComponent();
        }

        private void btnClose_Peyment_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn_rbHisob_Click(object sender, RoutedEventArgs e)
        {
            PeymentPage peymentPage = new PeymentPage();
            MainWindow.PageNavigator.Navigate(peymentPage);
        }

        private void btn_rbDavom_Click(object sender, RoutedEventArgs e)
        {
            TaomlarPage taomlarPage = new TaomlarPage();
            MainWindow.PageNavigator.Content = taomlarPage;
        }
    }
}
