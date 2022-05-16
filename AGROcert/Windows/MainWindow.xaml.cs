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

        public MainWindow()
        {
            InitializeComponent();

            s_window = this;
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
    }
}
