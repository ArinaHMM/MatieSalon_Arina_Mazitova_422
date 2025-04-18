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
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        public EmployeePage()
        {
            InitializeComponent();
            EmploDG.ItemsSource = App.db.Users.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEmploPage(null));
        }
       
           
        

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedSer = (Users)EmploDG.SelectedItem;

            if (selectedSer != null)
            {
                NavigationService.Navigate(new AddEmploPage(selectedSer));
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите коллекцию для редактирования.");
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
