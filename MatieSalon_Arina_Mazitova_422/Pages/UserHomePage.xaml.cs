using MatieSalon_Arina_Mazitova_422.DB;
using System.Windows;
using System.Windows.Controls;

namespace MatieSalon_Arina_Mazitova_422.Pages
{
    public partial class UserHomePage : Page
    {
        public Users CurrentUser { get; set; }

        public UserHomePage(Users user)
        {
            InitializeComponent();
            CurrentUser = user;

            ConfigureVisibilityBasedOnRole();
        }

        private void ConfigureVisibilityBasedOnRole()
        {
            switch (CurrentUser.RoleID)
            {
                case 1: 
                    LC.Visibility = Visibility.Visible;
                    Ser.Visibility = Visibility.Collapsed;
                    Coll.Visibility = Visibility.Collapsed;
                    Emp.Visibility = Visibility.Collapsed; 
                    break;

                case 3: 
                    LC.Visibility = Visibility.Collapsed;
                    Ser.Visibility = Visibility.Collapsed;
                    Coll.Visibility = Visibility.Collapsed;
                    Emp.Visibility = Visibility.Visible;   
                    break;

                case 4: 
                    LC.Visibility = Visibility.Collapsed;
                    Ser.Visibility = Visibility.Visible; 
                    Coll.Visibility = Visibility.Visible;  
                    Emp.Visibility = Visibility.Collapsed;   
                    break;

                default:
                    LC.Visibility = Visibility.Collapsed;
                    Ser.Visibility = Visibility.Collapsed;
                    Coll.Visibility = Visibility.Collapsed;
                    Emp.Visibility = Visibility.Collapsed;
                    break;
            }
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

        private void Backs_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthPage());
            CurrentUser = null;

        }
    }
}
