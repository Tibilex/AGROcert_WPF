using AGROcert.ViewModels;
using AGROcert.Windows.Pages;
using AGROcert.Windows.Pages.Cookies;
using AGROcert.Windows.Pages.Food;
using AGROcert.Windows.Pages.Juice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        private PagesPage _pagesPage;
        private ContactUsPage _contactUsPage;

        private CookiePage1 _cookiePage1;
        private CookiePage2 _cookiePage2;
        private CookiePage3 _cookiePage3;

        private FoodPage1 _foodPage1;
        private FoodPage2 _foodPage2;
        private FoodPage3 _foodPage3;

        private JuicePage1 _juicePage1;
        private JuicePage2 _juicePage2;
        private JuicePage3 _juicePage3;

        public MainWindow()
        {
            InitializeComponent();
            s_window = this;

            _homePage = new HomePage();
            _aboutPage = new AboutUsPage();
            _shopPage = new ShopPage();
            _contactUsPage = new ContactUsPage();
            _pagesPage = new PagesPage();

            _cookiePage1 = new CookiePage1();
            _cookiePage2 = new CookiePage2();
            _cookiePage3 = new CookiePage3();

            _foodPage1 = new FoodPage1();
            _foodPage2 = new FoodPage2();
            _foodPage3 = new FoodPage3();

            _juicePage1 = new JuicePage1();
            _juicePage2 = new JuicePage2();
            _juicePage3 = new JuicePage3();

            progpamPages.Navigate(_homePage);

            NavigationForPages();
        }

        private void NavigationForPages()
        {
            _aboutPage.Navigate = progpamPages;
            _homePage.Navigate = progpamPages;
            _aboutPage.Page = _shopPage;
            _homePage.Page = _aboutPage;

            _pagesPage.Navigate = progpamPages;
            _pagesPage.PageFood = _foodPage1;
            _pagesPage.PageJuice = _juicePage1;
            _pagesPage.PageCookie = _cookiePage1;

            _foodPage1.Navigate = progpamPages;
            _foodPage2.Navigate = progpamPages;
            _foodPage3.Navigate = progpamPages;
            _foodPage1.Page = _foodPage2;
            _foodPage2.Page = _foodPage3;
            _foodPage3.Page = _foodPage2;

            _juicePage1.Navigate = progpamPages;
            _juicePage2.Navigate = progpamPages;
            _juicePage3.Navigate = progpamPages;
            _juicePage1.Page = _juicePage2;
            _juicePage2.Page = _juicePage3;
            _juicePage3.Page = _juicePage2;

            _cookiePage1.Navigate = progpamPages;
            _cookiePage2.Navigate = progpamPages;
            _cookiePage3.Navigate = progpamPages;
            _cookiePage1.Page = _cookiePage2;
            _cookiePage2.Page = _cookiePage3;
            _cookiePage3.Page = _cookiePage2;
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
            progpamPages.Navigate(_pagesPage);
        }

        private void ContactsBtn_Click(object sender, RoutedEventArgs e)
        {
            progpamPages.Navigate(_contactUsPage);
        }
    }
}
