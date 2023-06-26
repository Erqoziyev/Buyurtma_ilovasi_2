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

namespace Buyurtma_ilovasi_2.Components
{
    /// <summary>
    /// Interaction logic for MealAddUserControl.xaml
    /// </summary>
    public partial class MealAddUserControl : UserControl
    {
        public int count { get; set; }
        public Action<AddValue> Add { get; set; }
        
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

            MainWindow mainWindow =GetMainWindow();

            AddValue addValue2 = new AddValue();
            if (int.Parse(tbCount.Text) > 0)
            {
                addValue2.TaomNomi = lblFoodName.Content.ToString();
                addValue2.Narxi = Convert.ToInt32(lblFoodPrice.Content.ToString());
                addValue2.Soni = Convert.ToInt32(tbCount.Text);
                mainWindow.AddDataToDataGrid(addValue2);
            }
            else
                MessageBox.Show("Nechta olishingizni kiriting!");
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
        public class AddValue
        {
            public string TaomNomi { get; set; } = String.Empty;
            public int Soni { get; set; }
            public float Narxi { get; set; }

        }
    

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            if(count > 0)
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
}
