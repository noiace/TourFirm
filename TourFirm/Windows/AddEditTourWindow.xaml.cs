using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;
using TourFirm.DataBase;
using TourFirm.Models;

namespace TourFirm.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditTourWindow.xaml
    /// </summary>
    public partial class AddEditTourWindow : Window
    {
        private Tour _currentTour = new Tour();
        private TourDbContext _context = TourDbContext.GetContext();
        public AddEditTourWindow(Tour selectedTour)
        {
            InitializeComponent();

            if (selectedTour != null) 
            {
                _currentTour = selectedTour;

                DataContext = _currentTour;
            }

            if (_currentTour.Id == 0)
            {
                _currentTour.From = DateTime.Now;
                _currentTour.To = DateTime.Now;
            }
        }

        private void buttonSaveTour_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentTour.Name))
            {
                errors.AppendLine("Наименование не может быть пустым");
            }

            if (_currentTour.From < DateTime.Now)
            {
                errors.AppendLine("Дата начала тура должна начинаться с завтрашнего дня");
            }

            if (_currentTour.From >= _currentTour.To)
            {
                errors.AppendLine("Дата конца тура должна быть позже начала");
            }

            if (_currentTour.Price <= 0)
            {
                errors.AppendLine("Цена должна быть больше 0");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            _currentTour.From = dpFrom.SelectedDate.Value.ToUniversalTime();
            _currentTour.To = dpTo.SelectedDate.Value.ToUniversalTime();

            if (_currentTour.Id == 0)
            {
                _context.Add(_currentTour);   
            }

            try
            {
                _context.SaveChanges();
                MessageBox.Show("Информация сохранена!");
                AdminPanel ap = new AdminPanel();
                ap.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            AdminPanel ap = new AdminPanel();
            ap.Show();
            this.Close();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text,0)) e.Handled = true;
        }

        private void btnUploadImage_Click(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            //ofd.FilterIndex = 1;

            //if (ofd.ShowDialog() == true)
            //{
            //    uploadedImage.Source = new BitmapImage(new Uri(ofd.FileName));
            //    _currentTour.Image = ofd.FileName.Split('\\').Last();

            //    string dest = "\\..\\..\\..\\Resources\\" + _currentTour.Image;
            //    byte[] fileBytes = File.ReadAllBytes(ofd.FileName);

            //    using (FileStream fs = new FileStream(dest, FileMode.Create))
            //    {
            //        fs.Write(fileBytes, 0, fileBytes.Length);
            //    }
            //}
        }
    }
}
