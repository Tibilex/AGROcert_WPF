using AGROcert.Models;
using AGROcert.Windows.Pages;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace AGROcert.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<ProductModel> Products { get; set; }

        public MainWindowViewModel()
        {
            Products = new ObservableCollection<ProductModel>();
            //Products.Add(new ProductModel("Клубника", 400));
            //Products.Add(new ProductModel("Арбуз", 100));
            //Products.Add(new ProductModel("Яблоко", 40));
            //Products.Add(new ProductModel("wdawdwa", 40));
            //Products.Add(new ProductModel("wada", 40));
            //Products.Add(new ProductModel("Ябadfdfлоко", 40));
            //Products.Add(new ProductModel("Ябvdsvsлоко", 40));
            //Products.Add(new ProductModel("Яблsdvоко", 40));
            //Products.Add(new ProductModel("Яблvxvоко", 40));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
