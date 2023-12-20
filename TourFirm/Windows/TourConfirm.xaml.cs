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
    /// Логика взаимодействия для TourRegistration.xaml
    /// </summary>
    public partial class TourConfirm : Window
    {
        private User _currentUser;
        private TourDbContext _context;
        private List<Cart> _userCart;
        public TourConfirm(User user, List<Cart> usercart)
        {
            InitializeComponent();
            _context = TourDbContext.GetContext();
            _currentUser = user;
            _userCart = usercart;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            TourCart tw = new TourCart(_currentUser);
            tw.Show();
            this.Close();
            
        }
            

        private void ButtonPay_Click(object sender, RoutedEventArgs e)
        {
            if (ArePaymentDetailsValid())
            {
                List<Order> orders = new List<Order>();

                foreach (var tour in _userCart)
                {
                    orders.Add(new Order
                    {
                        CreationDate = DateTime.Now.ToUniversalTime(),
                        UserId = _currentUser.Id,
                        Tour = tour.Tour,
                        Count = tour.Count
                    });
                }
                try
                {
                    _context.Carts.RemoveRange(_userCart);
                    _context.SaveChanges();
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    _context.Orders.AddRange(orders);
                    _context.SaveChanges();
                    MessageBox.Show("Your order has been successfully paid");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                TourPaid tw = new TourPaid();
                tw.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill in all payment details.");
            }

        }
        private bool ArePaymentDetailsValid()
        {
            return !string.IsNullOrWhiteSpace(TextBox_CreditCart.Text)
                && !string.IsNullOrWhiteSpace(TextBox_CVCCode.Text)
                && !string.IsNullOrWhiteSpace(DatePicker_Birthday.Text);
        }
    }
}
