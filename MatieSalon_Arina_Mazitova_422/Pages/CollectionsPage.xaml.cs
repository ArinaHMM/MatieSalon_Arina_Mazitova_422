using MatieSalon_Arina_Mazitova_422.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MatieSalon_Arina_Mazitova_422.Pages
{
    public partial class CollectionsPage : Page
    {
        public CollectionsPage()
        {
            InitializeComponent();
            LoadCollections();
        }

        private void LoadCollections()
        {
            CollDG.ItemsSource = App.db.Collections.ToList();
        }

        private void RefreshDataGrid()
        {
            CollDG.ItemsSource = App.db.Collections.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddCollectionPage(null));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedCollection = (Collections)CollDG.SelectedItem;

            if (selectedCollection != null)
            {
                NavigationService.Navigate(new AddCollectionPage(selectedCollection)); 
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите коллекцию для редактирования.");
            }
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedCollection = (Collections)CollDG.SelectedItem;

            if (selectedCollection != null)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить это?", "Удаление", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    App.db.Collections.Remove(selectedCollection);
                    App.db.SaveChanges();
                    LoadCollections(); 
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите коллекцию для удаления.");
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CollDG.ItemsSource = App.db.Collections.ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
