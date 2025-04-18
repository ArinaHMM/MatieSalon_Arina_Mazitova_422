using MatieSalon_Arina_Mazitova_422.Pages;
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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatieSalon_Arina_Mazitova_422
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new AuthPage());
            
        }
        
        private void NavButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnServices_Click(object sender, RoutedEventArgs e)
        {
            if(App.CurrentUser != null)
            {
                btnServices.Visibility = Visibility.Visible;
            }
            MainFrame.Navigate(new CollectionsPage());
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAppointments_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
