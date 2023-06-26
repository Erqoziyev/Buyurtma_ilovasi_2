using Buyurtma_ilovasi_2.Pages;
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
        public MainWindow()
        {
            InitializeComponent();
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


    }
}
