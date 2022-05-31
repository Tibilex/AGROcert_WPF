using AGROcert.ViewModels;
using System.Windows.Controls;

namespace AGROcert.Windows.Pages
{
    /// <summary>
    /// Логика взаимодействия для ShopPage.xaml
    /// </summary>
    public partial class ShopPage : Page
    {

        public ShopPage()
        {
            InitializeComponent();
            DataContext = new ShopViewModel();
        }           
    }
}
