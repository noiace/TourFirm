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
        public TourConfirm(User user)
        {
            InitializeComponent();
            _currentUser = user;
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
