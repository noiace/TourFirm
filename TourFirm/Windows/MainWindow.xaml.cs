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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TourFirm.DataBase;
using TourFirm.Models;

namespace TourFirm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TourDbContext _context = TourDbContext.GetContext();
        public MainWindow()
        {
            InitializeComponent();  
            // var context = TourDbContext.GetContext();
            //User user = new User() { Name = "Adel", Surname = "Galimov", Email = "a@mail.ru", Phone = "89870000123", UserName = "noiace", Password = "1234", DateOfBirth = new DateTime (2004, 9, 14).ToUniversalTime() };

            //context.Users.Add(user);
            //context.SaveChanges();

            //foreach (var user in context.Users)
            //{
            //    MessageBox.Show(user.Name);
            //}

        }

        private void Button_LogIn_Click(object sender, RoutedEventArgs e)
        {
            var login = TextBox_Login.Text;
            var password = TextBox_Password.Text;

            var user = _context.Users.Where(u => u.UserName == login && u.Password == password).FirstOrDefault();

            if (user != null)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("Invalid Credentials");
            }
        }

        private void Button_Open_SignUp_Click(object sender, RoutedEventArgs e)
        {
            Sign_Up sign = new Sign_Up();
            sign.Show();
            this.Close();
        }
    }
}
