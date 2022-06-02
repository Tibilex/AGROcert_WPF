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
    public class ShopViewModel : INotifyPropertyChanged
    {
        private string _connectionString = "Data Source = SQL8003.site4now.net,1433; Initial Catalog = db_a878c3_tibiriumtype; User Id = db_a878c3_tibiriumtype_admin; Password=tibirium1;";
        public ObservableCollection<ProductModel> Products { get; set; }

        public ShopViewModel()
        {
            Products = new ObservableCollection<ProductModel>();
            GetDataInDataBase();
        }

        private void GetDataInDataBase()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
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
                Products.Add(new ProductModel((int)productId, productName.ToString(), productType.ToString(), (int)price, category.ToString(), productImage));
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
