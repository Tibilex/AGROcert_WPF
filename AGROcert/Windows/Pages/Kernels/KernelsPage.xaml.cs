using AGROcert.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace AGROcert.Windows.Pages.Cookies
{
    /// <summary>
    /// Логика взаимодействия для KernelsPage.xaml
    /// </summary>
    public partial class KernelsPage : Page
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

        public KernelsPage()
        {
            InitializeComponent();
            DataContext = new KernelsViewModel();
        }

        private void PrevPageBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigate.GoBack();
        }
    }
}
