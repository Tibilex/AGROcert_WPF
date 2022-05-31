using AGROcert.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AGROcert.ViewModels
{
    public class FoodViewModel : INotifyPropertyChanged
    {
        private string _connectionString = "Data Source = SQL8003.site4now.net,1433; Initial Catalog = db_a878c3_tibiriumtype; User Id = db_a878c3_tibiriumtype_admin; Password=tibirium1;";
        public ObservableCollection<ProductModel> Products { get; set; }

        public FoodViewModel()
        {
            Products = new ObservableCollection<ProductModel>();
            GetDataInDataBase();
        }

        private void GetDataInDataBase()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("SELECT ProductName, ProductType, Price, Category, Image FROM Products WHERE Category  = 'Vegetables'", connection);
            connection.Open();
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                object productName = dataReader.GetValue(0);
                object productType = dataReader.GetValue(1);
                object price = dataReader.GetValue(2);
                object category = dataReader.GetValue(3);
                byte[] img = (byte[])dataReader.GetValue(4);
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
            Products.Add(new ProductModel(productName.ToString(), productType.ToString(), (int)price, category.ToString(), productImage));
            }
            dataReader.Close();
            connection.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
