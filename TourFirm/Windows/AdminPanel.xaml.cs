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
using System.Windows.Shapes;
using TourFirm.DataBase;
using TourFirm.Models;

namespace TourFirm.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        TourDbContext _context;
        public AdminPanel()
        {
            InitializeComponent();

            _context = TourDbContext.GetContext();
            dataGridTours.ItemsSource = _context.Tours.ToList();
        }

        private void AddTour_Click(object sender, RoutedEventArgs e)
        {
            AddEditTourWindow addEdit = new AddEditTourWindow(new Tour());
            addEdit.Show();
            this.Close();
        }

        private void DeleteTours_Click(object sender, RoutedEventArgs e)
        {
            var selectedTours = dataGridTours.SelectedItems.Cast<Tour>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить выбранные {selectedTours.Count()} туров ?",
                "Внимание",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    _context.Tours.RemoveRange(selectedTours);
                    _context.SaveChanges();
                    MessageBox.Show("Выбранные туры были удалены из базы данных.");

                    dataGridTours.ItemsSource = _context.Carts.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void EditTour_Click(object sender, RoutedEventArgs e)
        {
            AddEditTourWindow addEdit = new AddEditTourWindow((sender as Button).DataContext as Tour);
            addEdit.Show();
            this.Close();
        }

        private void ButtonGoToOrders_Click(object sender, RoutedEventArgs e)
        {
            AdminPanelOrders adminPanelOrders = new AdminPanelOrders();
            adminPanelOrders.Show();
            this.Close();
        }
    }
}
