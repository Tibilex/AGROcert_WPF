using AGROcert.ViewModels;
using System.Windows;
using System.Windows.Controls;
namespace AGROcert.Windows.Pages.Food
{
    /// <summary>
    /// Логика взаимодействия для FoodPage.xaml
    /// </summary>
    public partial class FoodPage : Page
    {
        private Frame _navigate;
        public Frame Navigate
        {
            get { return _navigate; }
            set { _navigate = value; }
        }

        private Page _page;
        public Page Page
        {
            get { return _page; }
            set { _page = value; }
        }

        public FoodPage()
        {
            InitializeComponent();
            DataContext = new FoodViewModel();
        }

        private void NextPageBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigate.Navigate(Page);
        }

        private void PrevPageBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigate.GoBack();
        }
    }
}
