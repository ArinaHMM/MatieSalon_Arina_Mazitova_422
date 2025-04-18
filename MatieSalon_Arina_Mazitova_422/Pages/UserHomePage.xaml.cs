using MatieSalon_Arina_Mazitova_422.DB;
using System.Windows;
using System.Windows.Controls;

namespace MatieSalon_Arina_Mazitova_422.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserHomePage.xaml
    /// </summary>
    public partial class UserHomePage : Page
    {
        public Users CurrentUser { get; set; }

        public UserHomePage(Users user)
        {
            InitializeComponent();
            CurrentUser = user;
        }

        private void LC_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserCabinetPage(CurrentUser));
        }

        private void Ser_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ServicesPage());
        }

        private void Coll_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CollectionsPage());
        }

        private void Emp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeePage());
        }
    }
}