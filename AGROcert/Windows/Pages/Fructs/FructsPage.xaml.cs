using AGROcert.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace AGROcert.Windows.Pages.Juice
{
    /// <summary>
    /// Логика взаимодействия для FructsPage.xaml
    /// </summary>
    public partial class FructsPage : Page
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

        public FructsPage()
        {
            InitializeComponent();
            DataContext = new FruitsViewModel();
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
