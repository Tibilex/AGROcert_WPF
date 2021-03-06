using System.Windows;
using System.Windows.Controls;

namespace AGROcert.Windows.Pages
{
    /// <summary>
    /// Логика взаимодействия для CategoryPage.xaml
    /// </summary>
    public partial class CategoryPage : Page
    {
        private Frame _navigate;
        public Frame Navigate
        {
            get { return _navigate; }
            set { _navigate = value; }
        }
        private Page _pageFood;
        public Page FoodPage
        {
            get { return _pageFood; }
            set { _pageFood = value; }
        }
        private Page _fruitsPage;
        public Page FruitsPage
        {
            get { return _fruitsPage; }
            set { _fruitsPage = value; }
        }
        private Page _kernelsPage;
        public Page KernelsPage
        {
            get { return _kernelsPage; }
            set { _kernelsPage = value; }
        }

        public CategoryPage()
        {
            InitializeComponent();
        }

        private void foodCategoryBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigate.Navigate(FoodPage);
        }

        private void juiceCategoryBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigate.Navigate(FruitsPage);
        }

        private void cookiesCategoryBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigate.Navigate(KernelsPage);
        }
    }
}
