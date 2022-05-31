using AGROcert.ViewModels;
using AGROcert.Windows.Pages;
using AGROcert.Windows.Pages.Cookies;
using AGROcert.Windows.Pages.Food;
using AGROcert.Windows.Pages.Juice;
using System;
using System.Windows;
using System.Windows.Input;

namespace AGROcert
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow s_window;
        private HomePage _homePage;
        private AboutUsPage _aboutPage;
        private ShopPage _shopPage;
        private CategoryPage _categoryPage;
        private ContactUsPage _contactUsPage;
        private KernelsPage _kernelsPage;
        private FoodPage _foodPage;
        private FructsPage _fruitsPage;
        private UserAuthorisationPage _userAuthorisationPage;
        private AccountManagmentPage _accountManagmentPage;

        public MainWindow()
        {
            InitializeComponent();
            s_window = this;

            _homePage = new HomePage();
            _aboutPage = new AboutUsPage();
            _shopPage = new ShopPage();
            _contactUsPage = new ContactUsPage();
            _categoryPage = new CategoryPage();
            _userAuthorisationPage = new UserAuthorisationPage();
            _accountManagmentPage = new AccountManagmentPage();

            _kernelsPage = new KernelsPage(); 
            _foodPage = new FoodPage();
            _fruitsPage = new FructsPage();

            progpamPages.Navigate(_homePage);

            NavigationForPages();
        }

        private void NavigationForPages()
        {
            _aboutPage.Navigate = progpamPages;
            _homePage.Navigate = progpamPages;
            _aboutPage.Page = _shopPage;
            _homePage.Page = _aboutPage;

            _userAuthorisationPage.Navigate = progpamPages;
            _accountManagmentPage.Navigate = progpamPages;

            _categoryPage.Navigate = progpamPages;
            _categoryPage.FoodPage = _foodPage;
            _categoryPage.FruitsPage = _fruitsPage;
            _categoryPage.KernelsPage = _kernelsPage;

            _foodPage.Navigate = progpamPages;
            _fruitsPage.Navigate = progpamPages;
            _kernelsPage.Navigate = progpamPages;

            _foodPage.Page = _fruitsPage;
            _fruitsPage.Page = _kernelsPage;
        }

        private void CloseWindow_Click(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MinimiseWindow_Click(object sender, EventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void WindowMoving_Click(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                s_window.DragMove();
            }
        }

        private void CartBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            progpamPages.Navigate(_homePage);
        }

        private void AboutBtn_Click(object sender, RoutedEventArgs e)
        {
            progpamPages.Navigate(_aboutPage);
        }

        private void MarketBtn_Click(object sender, RoutedEventArgs e)
        {
            progpamPages.Navigate(_shopPage);
        }

        private void PagesBtn_Click(object sender, RoutedEventArgs e)
        {
            progpamPages.Navigate(_categoryPage);
        }

        private void ContactsBtn_Click(object sender, RoutedEventArgs e)
        {
            progpamPages.Navigate(_contactUsPage);
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            progpamPages.Navigate(_userAuthorisationPage);
        }
    }
}
