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

namespace AGROcert.Windows.Pages.Food
{
    /// <summary>
    /// Логика взаимодействия для FoodPage3.xaml
    /// </summary>
    public partial class FoodPage3 : Page
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

        public FoodPage3()
        {
            InitializeComponent();
        }

        private void PrevPageBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigate.GoBack();
        }
    }
}
