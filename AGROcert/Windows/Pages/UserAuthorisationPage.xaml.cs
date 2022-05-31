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
    /// Логика взаимодействия для UserAuthorisationPage.xaml
    /// </summary>
    public partial class UserAuthorisationPage : Page
    {
        private Frame _navigate;

        public Frame Navigate
        {
            get { return _navigate; }
            set { _navigate = value; }
        }

        public UserAuthorisationPage()
        {
            InitializeComponent();
        }
    }
}
