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
    /// Логика взаимодействия для ServicesPage.xaml
    /// </summary>
    public partial class ServicesPage : Page
    {
        public ServicesPage()
        {
            InitializeComponent();
            SerDG.ItemsSource = App.db.Services.ToList();

        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddCollectionPage(null));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedSer = (Services)SerDG.SelectedItem;

            if (selectedSer != null)
            {
                NavigationService.Navigate(new AddServicePage(selectedSer));
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите коллекцию для редактирования.");
            }
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedSer = (Services)SerDG.SelectedItem;

            if (selectedSer != null)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить это?", "Удаление", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    App.db.Services.Remove(selectedSer);
                    App.db.SaveChanges();
                    
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите коллекцию для удаления.");
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SerDG.ItemsSource = App.db.Services.ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
