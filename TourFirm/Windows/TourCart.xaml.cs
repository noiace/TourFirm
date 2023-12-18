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
     
    }
}
