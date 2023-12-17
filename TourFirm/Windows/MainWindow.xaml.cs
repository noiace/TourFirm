using Microsoft.VisualBasic;
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
using System.Xml.Linq;
using TourFirm.DataBase;
using TourFirm.Models;
using TourFirm.Windows;

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
           /* // var context = TourDbContext.GetContext();
            //User user = new User() { Name = "Adel", Surname = "Galimov", Email = "a@mail.ru", Phone = "89870000123", UserName = "noiace", Password = "1234", DateOfBirth = new DateTime (2004, 9, 14).ToUniversalTime() };

            //context.Users.Add(user);
            //context.SaveChanges();

            //foreach (var user in context.Users)
            //{
            //    MessageBox.Show(user.Name);
            //}
            //var context = TourDbContext.GetContext();
            //Tour tour = new Tour() { Name = "Sunny Days Resort Spa", Price = 610, From = new DateTime(2023, 12, 21).ToUniversalTime(), To = new DateTime(2023, 12, 28).ToUniversalTime(), Description = "Sunny Days Resort Spa & Aqua Park находится в городе Хургада. Курортный комплекс состоит из двух частей, объединённых в один отель: Palma de Mirette (бывший отель Sunny Days Palma de Mirette) и El Palacio (бывший отель Sunny Days El Palacio). Всего в отеле 1023 номера. Отель построен в 2002 году, последняя реновация проводилась в 2021 году (реновация территории отеля, некоторых номеров категории Стандарт и Премиум). До центра города Хургада - 5 км. До Международного аэропорта Хургада (Hurghada International Airport) - 10 км.\r\n", Image = "SunnyDays.jpeg" };
            //context.Tours.Add(tour);
            //context.SaveChanges(); */
            var context = TourDbContext.GetContext();
            //Tour tour = new Tour() {};

              // context.Tours.Add(tour);
          //     context.SaveChanges();
        }

        private void Button_LogIn_Click(object sender, RoutedEventArgs e)
        {
            var login = TextBox_Login.Text;
            var password = TextBox_Password.Text;

            var user = _context.Users.Where(u => u.UserName == login && u.Password == password).FirstOrDefault();

            if (user != null)
            {
                MessageBox.Show("OK");
                TourWindow tw = new TourWindow();
                tw.Show();
                this.Close();
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
