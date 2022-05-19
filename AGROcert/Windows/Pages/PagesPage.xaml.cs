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

namespace AGROcert.Windows.Pages
{
    /// <summary>
    /// Логика взаимодействия для PagesPage.xaml
    /// </summary>
    public partial class PagesPage : Page
    {
        private Frame _navigate;
        public Frame Navigate
        {
            get { return _navigate; }
            set { _navigate = value; }
        }
        private Page _pageFood;
        public Page PageFood
        {
            get { return _pageFood; }
            set { _pageFood = value; }
        }
        private Page _pageJuice;
        public Page PageJuice
        {
            get { return _pageJuice; }
            set { _pageJuice = value; }
        }
        private Page _pageCookie;
        public Page PageCookie
        {
            get { return _pageCookie; }
            set { _pageCookie = value; }
        }

        public PagesPage()
        {
            InitializeComponent();
        }

        private void foodCategoryBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigate.Navigate(PageFood);
        }

        private void juiceCategoryBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigate.Navigate(PageJuice);
        }

        private void cookiesCategoryBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigate.Navigate(PageCookie);
        }
    }
}
