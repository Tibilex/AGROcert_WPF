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
        private List<Page> _listPages;

        public MainWindow()
        {
            InitializeComponent();
            s_window = this;

            _listPages = new List<Page>();
            _listPages.Add(new HomePage());
            _listPages.Add(new AboutUsPage());
            _listPages.Add(new ShopPage());
            _listPages.Add(new PagesPage());
            _listPages.Add(new ContactUsPage());

            progpamPages.Content = _listPages[0];

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
            progpamPages.Content = _listPages[0];
        }

        private void AboutBtn_Click(object sender, RoutedEventArgs e)
        {
            progpamPages.Content = _listPages[1];
        }

        private void MarketBtn_Click(object sender, RoutedEventArgs e)
        {
            progpamPages.Content = _listPages[2];
        }

        private void PagesBtn_Click(object sender, RoutedEventArgs e)
        {
            progpamPages.Content = _listPages[3];
        }

        private void ContactsBtn_Click(object sender, RoutedEventArgs e)
        {
            progpamPages.Content = _listPages[4];
        }
    }
}
