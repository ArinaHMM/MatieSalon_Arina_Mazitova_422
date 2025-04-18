using MatieSalon_Arina_Mazitova_422.DB;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddCollectionPage.xaml
    /// </summary>
    public partial class AddCollectionPage : Page
    {
        private Collections _collections;
        private byte[] _imageData = null;

        public AddCollectionPage(Collections collections)
        {
            InitializeComponent();

            _collections = collections ?? new Collections();

            DataContext = _collections;

            NameTextBox.Text = _collections.Name;
            DesTextBox.Text = _collections.Description;
            _imageData = _collections.ImagePath;
            PreviewImage.Source = LoadImage(_imageData);
        }

        private BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
                return new BitmapImage(new Uri("Images/Logo.ico", UriKind.Relative));

            using (var stream = new MemoryStream(imageData))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = stream;
                image.EndInit();
                return image;
            }
        }

        private void UploadImage_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Изображения (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                _imageData = File.ReadAllBytes(openFileDialog.FileName);
                PreviewImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _collections.Name = NameTextBox.Text;
                _collections.Description = DesTextBox.Text;
                _collections.ImagePath = _imageData;

                if (_collections.CollectionID == 0) 
                {
                    App.db.Collections.Add(_collections);
                }

                App.db.SaveChanges();
                MessageBox.Show("Коллекция успешно сохранена");
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
            }
        }
    }
}