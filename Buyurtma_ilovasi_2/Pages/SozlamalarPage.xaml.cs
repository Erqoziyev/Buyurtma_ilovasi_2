using Buyurtma_ilovasi_2.Constans;
using Buyurtma_ilovasi_2.Entities.Products;
using Buyurtma_ilovasi_2.Enums;
using Buyurtma_ilovasi_2.Halpers;
using Buyurtma_ilovasi_2.Interface.Products;
using Buyurtma_ilovasi_2.Repositories.Products;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        string path = string.Empty;
        public long Id { get; set; }
        private readonly IProductRepository _productRepository;
        private int id;

        public SozlamalarPage()
        {
            InitializeComponent();
            this._productRepository = new ProductRepository();
        }

        private void btnImgSave_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = GetImgDialog();
            if (openFileDialog.ShowDialog() == true)
            { 
                 path = openFileDialog.FileName;
                ImgBrush.ImageSource = new BitmapImage(new Uri(path, UriKind.Relative));
            }

        }
        private OpenFileDialog GetImgDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            return openFileDialog;

        }

        private async void btnSaqlash_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            

            if (tbMaxsulotNomi.Text != "" && tbMaxsulotNarxi.Text != "" && path != "" && Id > 0)
            {
                string imagepath = ImgBrush.ImageSource.ToString();

                if (!Directory.Exists(ContentConstans.IMAGE_CONTENTS_PATH))
                    Directory.CreateDirectory(ContentConstans.IMAGE_CONTENTS_PATH);


                var imageName = ContentNameMarker.GetImageName(imagepath);

                path = System.IO.Path.Combine(ContentConstans.IMAGE_CONTENTS_PATH, imageName);

                byte[] image = await File.ReadAllBytesAsync(imagepath);

                await File.WriteAllBytesAsync(path, image);

                product.Name = tbMaxsulotNomi.Text;
                product.Price = int.Parse(tbMaxsulotNarxi.Text);
                product.ImgPath = path;
                product.CatigoryId = Id;

                var result = await _productRepository.CreateAsync(product);
                tbMaxsulotNarxi.Text = string.Empty;
                tbMaxsulotNomi.Text = string.Empty;
                ImgBrush.ImageSource = null;
                path = string.Empty;

                MessageBox.Show("Malumotlar saqlandi!");
            }
            else MessageBox.Show("Ma'lumotlar to'liq kiritilmagan!");
        }

        private void btnMaxsulotTuri(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
        
            RadioButton radioButton = (RadioButton)sender;
            
            string ?btnName = radioButton.Content.ToString();

            if (btnName == "Taom") Id = 1 ;
            else if(btnName =="Kabob") Id = 2;
            else if(btnName =="Ichimlik") Id = 3;
            else if(btnName =="Salat") Id = 4;
            else if(btnName =="Shirinlik") Id = 5;
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
    }
}
