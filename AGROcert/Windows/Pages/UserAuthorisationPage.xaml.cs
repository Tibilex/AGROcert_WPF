using AGROcert.Controler;
using System.Windows;
using System.Windows.Controls;

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

            if (loginEmailTextBox.Text != "" && passwordEmailTextBox.Password != "")
            {
                if (UserConnect.CheckEmailUser(loginEmailTextBox.Text) || UserConnect.CheckEmailAdministrator(passwordEmailTextBox.Password))
                {
                    if(UserConnect.CheckPasswordUser(passwordEmailTextBox.Password) || UserConnect.CheckPasswordAdministrator(passwordEmailTextBox.Password))
                    {
                        if (UserConnect.LoginUser(loginEmailTextBox.Text, passwordEmailTextBox.Password))
                        {
                            MessageBox.Show("Вы успешно вошли в ваш аккаунт!");
                            Navigate.Navigate(Page);
                        }
                        else if (UserConnect.LoginAdministrator(loginEmailTextBox.Text, passwordEmailTextBox.Password))
                        {
                            MessageBox.Show("Вы успешно вошли в ваш управляющий аккаунт!");
                            Navigate.Navigate(AdminPage);
                        }
                    }
                    else
                    {
                        invalidPassword.Text = "Не верный пароль";
                    }
                }
                else
                {
                    inavalidEmail.Text = "Пользователя не существует";
                }
            }
            else
            {
                if (loginEmailTextBox.Text == "" || passwordEmailTextBox.Password == "")
                {                 
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
                requiredEmail.Text = "Не может быть пустым";
                requiredPass.Text = "Не может быть пустым";
            }
        }
    }
}
