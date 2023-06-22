using Microsoft.Win32;
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
    /// Interaction logic for SozlamalarPage.xaml
    /// </summary>
    public partial class SozlamalarPage : Page
    {
        public SozlamalarPage()
        {
            InitializeComponent();
        }

        private void btnImgSave_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = GetImgDialog();
            if (openFileDialog.ShowDialog() == true)
            { 
                string imgPath = openFileDialog.FileName;
                ImgBrush.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
            }

        }
        private OpenFileDialog GetImgDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = " Jpg files (*.jpg)|*.jpg  | Jpeg files (*.jpeg)|*.jpeg |Png files (*.png)|*.png";
            return openFileDialog;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
