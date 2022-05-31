using System.Windows;
using System.Windows.Controls;

namespace AGROcert.Windows.Pages
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
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

        public HomePage()
        {
            InitializeComponent();
        }

        private void exploreBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigate.Navigate(Page);
        }
    }
}
