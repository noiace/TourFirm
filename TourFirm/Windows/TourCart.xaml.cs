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
    /// Логика взаимодействия для TourCart.xaml
    /// </summary>
    public partial class TourCart : Window
    {
        private User _currentUser;
        private TourDbContext _context;
        public TourCart(User user)
        {
            InitializeComponent();
            _currentUser = user;
            _context = TourDbContext.GetContext();

            var userCart = _context.Carts.Where(c => c.UserId == _currentUser.Id).ToList();

            dataGridCart.ItemsSource = userCart;
        }
        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            TourWindow tw = new TourWindow(_currentUser);
            tw.Show();
            this.Close();
        }

        private void DeleteFromCart_Click(object sender, RoutedEventArgs e)
        {
            var selectedCartTours = dataGridCart.SelectedItems.Cast<Cart>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить выбранные {selectedCartTours.Count()} туров из корзины ?",
                "Внимание",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    _context.Carts.RemoveRange(selectedCartTours);
                    _context.SaveChanges();
                    MessageBox.Show("Выбранные туры были удалены из корзины");

                    dataGridCart.ItemsSource = _context.Carts.ToList();
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message.ToString());
                }   
            }
        }

        private void btnMinusOne_Click(object sender, RoutedEventArgs e)
        {
            var cartTour = (sender as Button).DataContext as Cart;

            cartTour.Count--;
            if (cartTour.Count == 0)
            {
                _context.Carts.Remove(cartTour);
            }
            else
            {
                _context.Carts.Update(cartTour);
            }            
            _context.SaveChanges();
            dataGridCart.ItemsSource = _context.Carts.ToList();
        }

        private void btnPlusOne_Click(object sender, RoutedEventArgs e)
        {
            var cartTour = (sender as Button).DataContext as Cart;

            cartTour.Count++;
            _context.Carts.Update(cartTour);
            _context.SaveChanges();
            dataGridCart.ItemsSource = _context.Carts.ToList();
        }
    }
}
