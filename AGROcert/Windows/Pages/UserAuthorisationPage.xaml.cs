using AGROcert.Controler;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AGROcert.Windows.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserAuthorisationPage.xaml
    /// </summary>
    public partial class UserAuthorisationPage : Page
    {
        private Frame _navigate;
        private Page _page;
        private Page _adminPage;

        public Page Page
        {
            get { return _page; }
            set { _page = value; }
        }
        public Page AdminPage
        {
            get { return _adminPage; }
            set { _adminPage = value; }
        }
        public Frame Navigate
        {
            get { return _navigate; }
            set { _navigate = value; }
        }

        public UserAuthorisationPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            inavalidEmail.Text = "";
            invalidPassword.Text = "";
            loginEmailTextBox.Foreground = new SolidColorBrush(Color.FromRgb(39, 76, 91));
            passwordEmailTextBox.Foreground = new SolidColorBrush(Color.FromRgb(39, 76, 91));
            loginEmailTextBox.CaretBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            passwordEmailTextBox.CaretBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            if (loginEmailTextBox.Text != "" && passwordEmailTextBox.Password != "")
            {
                if (UserConnect.CheckEmailUser(loginEmailTextBox.Text) || UserConnect.CheckEmailAdministrator(loginEmailTextBox.Text))
                {
                    if(UserConnect.CheckPasswordUser(passwordEmailTextBox.Password) || UserConnect.CheckPasswordAdministrator(passwordEmailTextBox.Password))
                    {
                        if (UserConnect.LoginUser(loginEmailTextBox.Text, passwordEmailTextBox.Password))
                        {
                            loginEmailTextBox.Background = new SolidColorBrush(Color.FromRgb(193, 218, 186));
                            passwordEmailTextBox.Background = new SolidColorBrush(Color.FromRgb(193, 218, 186));
                            MessageBox.Show("Вы успешно вошли в ваш аккаунт!");
                            Navigate.Navigate(Page);
                        }
                        else if (UserConnect.LoginAdministrator(loginEmailTextBox.Text, passwordEmailTextBox.Password))
                        {
                            loginEmailTextBox.Background = new SolidColorBrush(Color.FromRgb(193, 218, 186));
                            passwordEmailTextBox.Background = new SolidColorBrush(Color.FromRgb(193, 218, 186));
                            MessageBox.Show("Вы успешно вошли в ваш управляющий аккаунт!");
                            Navigate.Navigate(AdminPage);
                        }
                    }
                    else
                    {
                        passwordEmailTextBox.Background = new SolidColorBrush(Color.FromRgb(227, 119, 87));
                        passwordEmailTextBox.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                        passwordEmailTextBox.CaretBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                        loginEmailTextBox.CaretBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                        loginEmailTextBox.Background = new SolidColorBrush(Color.FromRgb(193, 218, 186));
                        invalidPassword.Text = "Не верный пароль";
                    }
                }
                else
                {
                    loginEmailTextBox.Background = new SolidColorBrush(Color.FromRgb(227, 119, 87));
                    loginEmailTextBox.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    passwordEmailTextBox.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    loginEmailTextBox.CaretBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    passwordEmailTextBox.CaretBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    inavalidEmail.Text = "Пользователя не существует";
                }
            }
            else
            {
                if (loginEmailTextBox.Text == "" || passwordEmailTextBox.Password == "")
                {   
                    loginEmailTextBox.Background = new SolidColorBrush(Color.FromRgb(227, 119, 87));
                    loginEmailTextBox.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    passwordEmailTextBox.Background = new SolidColorBrush(Color.FromRgb(227, 119, 87));
                    passwordEmailTextBox.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    loginEmailTextBox.CaretBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    passwordEmailTextBox.CaretBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    inavalidEmail.Text = "Заполните здесь";
                    invalidPassword.Text = "Заполните здесь";
                }
            }
            
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            if(userEmail.Text != "" && userPassword.Text != "")
            {
                UserConnect.RegistrationUser(userEmail.Text, userPassword.Text, userName.Text, userSurname.Text, userPhone.Text);
            }
            else
            {
                userEmail.Background = new SolidColorBrush(Color.FromRgb(227, 119, 87));
                userPassword.Background = new SolidColorBrush(Color.FromRgb(227, 119, 87));
                requiredEmail.Text = "Не может быть пустым";
                requiredPass.Text = "Не может быть пустым";
            }
        }
    }
}
