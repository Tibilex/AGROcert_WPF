using AGROcert.ViewModels;
using AGROcert.Windows.Pages;
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

        public MainWindow()
        {
            InitializeComponent();
            s_window = this;

            _homePage = new HomePage();
            _aboutPage = new AboutUsPage();
            _shopPage = new ShopPage();
            _contactUsPage = new ContactUsPage();
            _pagesPage = new PagesPage();

            progpamPages.Navigate(_homePage);
            _aboutPage.Navigate = progpamPages;
            _homePage.Navigate = progpamPages;
            _aboutPage.Page = _shopPage;
            _homePage.Page = _aboutPage;
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
