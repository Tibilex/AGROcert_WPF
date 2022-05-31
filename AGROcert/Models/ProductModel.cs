using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace AGROcert.Models
{
    public class ProductModel : INotifyPropertyChanged
    {
        private string _productName;
        private int _price;
        private string _productType;
        private string _category;
        private Byte[] _image;
        private ImageSource _imgSource;

        public string ProductName
        {
            get { return _productName; }
            set 
            {
                _productName = value;
                OnPropertyChanged("ProductName");
            }
        }
        public string ProductType
        {
            get { return _productType; }
            set 
            { 
                _productType = value; 
                OnPropertyChanged("ProductType");
            }
        }
        public int Price
        {
            get { return _price; }
            set
            {
                _price = value; 
                OnPropertyChanged("Price");
            }
        }
        public Byte[] Image
        {
            get { return _image; }
            set { 
                _image = value;                
            }
        }
        public string Category
        {
            get { return _category; }
            set 
            { 
                _category = value; 
                OnPropertyChanged("Category");
            }
        }
        public ImageSource ImgSource
        {
            get { return _imgSource; }
            set 
            { 
                _imgSource = value; 
                OnPropertyChanged("ImgSource");
            }
        }

        public ProductModel(string name, string type, int price, string category, ImageSource image)
        {
            ProductName = name;
            ProductType = type;
            Price = price;
            Category = category;
            ImgSource = image;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
