using AGROcert.Models;
using AGROcert.ViewModels;
using Dapper.Contrib.Extensions;
using Microsoft.Win32;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace AGROcert.Windows.Pages
{
    /// <summary>
    /// Логика взаимодействия для AccountManagmentPage.xaml
    /// </summary>
    public partial class AccountManagmentPage : Page
    {
        private Frame _navigate;
        private OpenFileDialog _openFileDialog;
        private string _fileName;

        private string _connectionString = "Data Source = SQL8003.site4now.net,1433; Initial Catalog = db_a878c3_tibiriumtype; User Id = db_a878c3_tibiriumtype_admin; Password=tibirium1;";
        private string _imageFormatFilter =
            $"Все файлы изображений (*.BMP,*.DIB,*.RLE,*.JPG,*.JPEG,*.JPE,*.JFIF,*.GIF,*.EMF,*.WMF,*.TIFF,*.PNG,*.ICO)|*.bmp;*.dib;*.rle;*.jpg;*.jpeg;*.jpe;*.jfif;*.gif;*.emf;*.wmf;*.tiff;*.png;*.ico|" +
            "BMP (*.BMP,*.DIB,*.RLE)|*.bmp;*.dib;*.rle|" +
            "JPEG (*.JPG,*.JPEG,*.JPE,*.JFIF)|*.jpg;*.jpeg;*.jpe;*.jfif|" +
            "GIF (*.GIF)|*.gif|" +
            "EMF (*.EMF)|*.emf|" +
            "WMF (*.WMF)|*.wmf|" +
            "TIFF (*.TIFF)|*.tiff|" +
            "PNG (*.PNG)|*.png|" +
            "ICO (*.ICO)|*.ico|" +
            "Все файлы (*.*)|*.*";

        public Frame Navigate
        {
            get { return _navigate; }
            set { _navigate = value; }
        }

        public AccountManagmentPage()
        {
            InitializeComponent();
            _openFileDialog = new OpenFileDialog();
            DataContext = new AdminProfileViewModel();
            listboxdatacontext.DataContext = new ShopViewModel();
            _fileName = "";
        }

        private void gitLink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("www.github.com/Tibilex/AGROcert_WPF");
        }

        private void AddImageButton_Click(object sender, RoutedEventArgs e)
        {
            _openFileDialog.Filter = _imageFormatFilter;
            _openFileDialog.ShowDialog();
            _fileName = _openFileDialog.FileName;
        }

        private void AddToBaseButton_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                Product product = new Product();
                product.ProductName = addProductName.Text;
                product.ProductType = addProductType.Text;
                product.Price = Convert.ToInt32(addProductPrice.Text);
                product.Category = addProductCategory.Text;
                product.Image = File.ReadAllBytes(_fileName);
                connection.Insert(product);
                addReport.Visibility = Visibility.Visible;
            }
        }

        private void sortToName_Click(object sender, RoutedEventArgs e)
        {

        }

        private void sortToType_Click(object sender, RoutedEventArgs e)
        {

        }

        private void sortToPrice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SortToCategory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void udateSelected_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteSelected_Click(object sender, RoutedEventArgs e)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                
            }
        }


    }
}
