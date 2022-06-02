using AGROcert.Models;
using AGROcert.ViewModels;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
        List<ProductModel> products;
        private static string s_connectionString = "Data Source = SQL8003.site4now.net,1433; Initial Catalog = db_a878c3_tibiriumtype; User Id = db_a878c3_tibiriumtype_admin; Password=tibirium1;";
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
            products = new List<ProductModel>();
            GetDataInDataBase();
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
            using (SqlConnection connection = new SqlConnection(s_connectionString))
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

        private void SortToVegetables_Click(object sender, RoutedEventArgs e)
        {
            listboxdatacontext.DataContext = new FoodViewModel();
            addReport.Visibility = Visibility.Hidden;
            UpdateLayout();
        }

        private void SortToKernels_Click(object sender, RoutedEventArgs e)
        {
            listboxdatacontext.DataContext = new KernelsViewModel();
            addReport.Visibility = Visibility.Hidden;
            UpdateLayout();
        }

        private void sortToFruits_Click(object sender, RoutedEventArgs e)
        {
            listboxdatacontext.DataContext = new FruitsViewModel();
            addReport.Visibility = Visibility.Hidden;
            UpdateLayout();
        }

        private void DisplayAll_Click(object sender, RoutedEventArgs e)
        {
            listboxdatacontext.DataContext = new ShopViewModel();
            addReport.Visibility = Visibility.Hidden;
            UpdateLayout();
        }

        private void udateSelected_Click(object sender, RoutedEventArgs e)
        {
            ProductModel product = (ProductModel)listboxdatacontext.SelectedItem;

            using (SqlConnection connection = new SqlConnection(s_connectionString))
            {
                
                foreach (ProductModel it in products)
                {
                    if (it.Id == product.Id)
                    {
                        string sqlExpression = $"UPDATE Products SET ProductName=@name, ProductType=@type, Price=@price, Image=@image WHERE Id=@id";
                        SqlCommand command = new SqlCommand();
                        command.CommandType = CommandType.Text;
                        command.Connection = connection;
                        command.CommandText = sqlExpression;
                        command.Parameters.AddWithValue("@name", addProductName.Text);
                        command.Parameters.AddWithValue("@type", addProductType.Text);
                        command.Parameters.AddWithValue("@price", Convert.ToInt32(addProductPrice.Text));
                        command.Parameters.AddWithValue("@image", File.ReadAllBytes(_fileName));
                        command.Parameters.AddWithValue("@id", it.Id);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
        }

        private void deleteSelected_Click(object sender, RoutedEventArgs e)
        {
            ProductModel product = (ProductModel)listboxdatacontext.SelectedItem;
           //string sqlExpression = $"DELETE FROM Products WHERE Id='0'";           

            using (SqlConnection connection = new SqlConnection(s_connectionString))
            {
                connection.Open();
                foreach (ProductModel it in products)
                {
                    if (it.Id == product.Id)
                    {
                        string sqlExpression = $"DELETE FROM Products WHERE Id='{it.Id}'";
                        SqlCommand command = new SqlCommand(sqlExpression, connection);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private void GetDataInDataBase()
        {
            SqlConnection connection = new SqlConnection(s_connectionString);
            SqlCommand command = new SqlCommand("SELECT * FROM Products", connection);
            connection.Open();
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                object productId = dataReader.GetValue(0);
                object productName = dataReader.GetValue(1);
                object productType = dataReader.GetValue(2);
                object price = dataReader.GetValue(3);
                object category = dataReader.GetValue(4);
                var img = (byte[])dataReader.GetValue(5);

                ImageSource productImage = null;

                MemoryStream memoryStream = new MemoryStream(img);
                var image = new BitmapImage();
                using (var mem = memoryStream)
                {
                    mem.Position = 0;
                    image.BeginInit();
                    image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.UriSource = null;
                    image.StreamSource = mem;
                    image.EndInit();
                }
                image.Freeze();
                productImage = image;
                products.Add(new ProductModel((int)productId, productName.ToString(), productType.ToString(), (int)price, category.ToString(), productImage));
            }
            dataReader.Close();
            connection.Close();
        }
    }
}
