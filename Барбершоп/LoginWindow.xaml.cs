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
using System.Windows.Shapes;

namespace Барбершоп
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private group_3_is_31Context _dbContext = new group_3_is_31Context();
        private bool _isLogin = false;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = _dbContext.Users.Where(
                    (usr) => usr.Login == loginTextBox.Text && usr.Password == passwordTextBox.Text).Single();
                MessageBox.Show($"Привет, {user.Login}!", "Успешно!");

                _isLogin = true;
                Close();
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Неверный логин и пароль!");
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (!_isLogin)
                App.Current.Shutdown();
        }
    }
}
