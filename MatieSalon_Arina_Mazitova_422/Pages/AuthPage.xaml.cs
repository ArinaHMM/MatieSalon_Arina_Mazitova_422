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

namespace MatieSalon_Arina_Mazitova_422.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string useremail = LoginTb.Text.Trim();
            string userpas = PasswordTb.Password.Trim();

            var user = App.db.Users.FirstOrDefault(u => u.Email == useremail && u.PasswordHash == userpas);

            if (user != null)
            {
                MessageBox.Show("Вы вошли!");
                NavigationService.Navigate(new UserCabinetPage(user));
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.");
            }
        }

        

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
   
