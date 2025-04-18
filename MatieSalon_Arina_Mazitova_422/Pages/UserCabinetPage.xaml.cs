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
    /// Логика взаимодействия для UserCabinetPage.xaml
    /// </summary>
    public partial class UserCabinetPage : Page
    {
        private Users CurrentUser;

        public UserCabinetPage(Users user)
        {
            InitializeComponent();
            CurrentUser = user;
            LoadUserData();
        }

        private void LoadUserData()
        {
            FullNameText.Text = CurrentUser.FullName;
            EmailText.Text = CurrentUser.Email;
            PhoneText.Text = string.IsNullOrEmpty(CurrentUser.Phone) ? "Не указан" : CurrentUser.Phone;
            BalanceText.Text = $"{CurrentUser.Balance:F2} ₽";
            RegDateText.Text = CurrentUser.RegistrationDate.ToString();
        }

        private void TopUpBalance_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(TopUpAmountTb.Text.Trim(), out decimal amount) && amount > 0)
            {
                CurrentUser.Balance += amount;
                App.db.SaveChanges();

                BalanceText.Text = $"{CurrentUser.Balance:F2} ₽";
                MessageBox.Show($"Счёт пополнен на {amount}₽");
                TopUpAmountTb.Clear();
            }
            else
            {
                MessageBox.Show("Введите корректную сумму.");
            }
        }
    }
}