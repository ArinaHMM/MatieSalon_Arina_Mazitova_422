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
    /// Логика взаимодействия для AddServicePage.xaml
    /// </summary>
    public partial class AddServicePage : Page
    {
        private Services _service;
        private byte[] _imageData;

        public AddServicePage(Services service = null)
        {
            InitializeComponent();
            _service = service ?? new Services();
            DataContext = _service;

            // Загрузка данных для ComboBox
            CollectionCombo.ItemsSource = App.db.Collections.ToList();
            CategoryCombo.ItemsSource = App.db.ServiceCategories.ToList();

            if (service != null)
            {
                _imageData = service.ImagePath;
                PreviewImage.Source = LoadImage(_imageData);
            }
        }

        private BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;

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
                _service.ImagePath = _imageData;
                _service.UpdatedAt = DateTime.Now;

                if (_service.ServiceID == 0)
                {
                    _service.CreatedAt = DateTime.Now;
                    App.db.Services.Add(_service);
                }

                App.db.SaveChanges();
                MessageBox.Show("Услуга сохранена успешно!");
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}

