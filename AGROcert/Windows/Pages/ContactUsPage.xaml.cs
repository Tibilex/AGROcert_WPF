using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для ContactUsPage.xaml
    /// </summary>
    public partial class ContactUsPage : Page
    {
        public ContactUsPage()
        {
            InitializeComponent();
        }

        private void FacebookLink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("www.facebook.com/itstep.kam");
        }
        private void InstagrammLink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("www.instagram.com/itstep_kamenskoe");
        }
        private void GitLink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("www.github.com/Tibilex/AGROcert_WPF");
        }
        private void WebsiteLink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("www.kam.itstep.org");
        }
    }
}
