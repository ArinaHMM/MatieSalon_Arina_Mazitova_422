using MatieSalon_Arina_Mazitova_422.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            string fullname = FullNameTb.Text.Trim();
            string email = EmailTb.Text.Trim();
            string phone = PhoneTb.Text.Trim();
            string username = UsernameTb.Text.Trim();
            string password = PasswordTb.Password.Trim();
            string bio = BioTb.Text.Trim();

            

            if (App.db.Users.Any(u => u.Email == email || u.Username == username))
            {
                MessageBox.Show("Такой пользователь уже существует.");
                return;
            }


            var newUser = new Users
            {
                FullName = fullname,
                Email = email,
                Phone = phone,
                Username = username,
                PasswordHash = password,
                Bio = bio,
                RoleID = 1, 
                Balance = 0.00m,
                QualificationLevel = 1,
                IsActive = true,
                RegistrationDate = DateTime.Now
            };

            App.db.Users.Add(newUser);
            App.db.SaveChanges();

            MessageBox.Show("Регистрация прошла успешно!");
            NavigationService.GoBack(); 
        }

      
    }
}

