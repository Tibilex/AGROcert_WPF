using System.Windows;
using System.Windows.Controls;

namespace AGROcert.Windows.Pages
{
    /// <summary>
    /// Логика взаимодействия для AboutUsPage.xaml
    /// </summary>
    public partial class AboutUsPage : Page
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

        public AboutUsPage()
        {
            InitializeComponent();
            
        }

        private void toShopBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigate.Navigate(Page);
        }
        
    }
}
