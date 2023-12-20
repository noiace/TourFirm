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

namespace TourFirm.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdminPanelOrders.xaml
    /// </summary>
    public partial class AdminPanelOrders : Window
    {
        private TourDbContext _context;
        public AdminPanelOrders()
        {
            InitializeComponent();

            _context = TourDbContext.GetContext();
            dataGridOrders.ItemsSource = _context.Orders.ToList();
        }

        private void GoToTours_Click(object sender, RoutedEventArgs e)
        {
            AdminPanel ap = new AdminPanel();
            ap.Show();
            this.Close();
        }
    }
}
