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
    /// Логика взаимодействия для TourWindow.xaml
    /// </summary>
    public partial class TourWindow : Window
    {
        private TourDbContext _context;
        private List<Tour> _tours;
        private User _currentUser;
        public TourWindow(User user)
        {
            InitializeComponent();

            _context = TourDbContext.GetContext();
            _tours = _context.Tours.ToList();

            ListView_Tours.ItemsSource = _tours;
            _currentUser = user;
        }
        private void Button_Open_TourCart_Click(object sender, RoutedEventArgs e)
        {
            TourCart cart = new TourCart(_currentUser);
            cart.Show();
            this.Close();
        }
        private void Button_Minus_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Plus_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Add_Tour_Click(object sender, RoutedEventArgs e)
        {
            var selectedTour = (sender as Button).DataContext as Tour;
            if (selectedTour != null)
            {
                Cart tourToCart = new Cart() { User = _currentUser, Tour = selectedTour };
                _context.Carts.Add(tourToCart);
                _context.SaveChanges();
                MessageBox.Show("Tour added to cart");
            }            
        }
    }
}
