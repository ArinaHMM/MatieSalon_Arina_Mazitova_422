using MatieSalon_Arina_Mazitova_422.DB;
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
    /// Логика взаимодействия для AddEmploPage.xaml
    /// </summary>
    public partial class AddEmploPage : Page
    {
        Users users;
        public AddEmploPage(Users _users)
        {
            InitializeComponent();
            _users = _users ?? new Users();

            DataContext = _users;
             
            FullNameTb.Text = _users.FullName;
            EmailTb.Text = _users.Email;
            PhoneTb.Text = _users.Phone;
            UsernameTb.Text = _users.Username;
            PasswordTb.Text = _users.PasswordHash;
            BioTb.Text = _users.Bio;
        }


        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            string fullname = FullNameTb.Text.Trim();
            string email = EmailTb.Text.Trim();
            string phone = PhoneTb.Text.Trim();
            string username = UsernameTb.Text.Trim();
            string password = PasswordTb.Text.Trim();
            string bio = BioTb.Text.Trim();

            var existingUser = App.db.Users.FirstOrDefault(u => u.Email == email || u.Username == username);
            if (existingUser != null)
            {
                MessageBox.Show("Пользователь с таким email или именем уже существует.");
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
    