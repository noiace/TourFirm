using Microsoft.EntityFrameworkCore;
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

namespace TourFirm
{
    public partial class Sign_Up : Window
    {
        public Sign_Up()
        {
            InitializeComponent();
        }
        
        private TourDbContext _context = TourDbContext.GetContext();
        
        private void Button_SignUp_Click(object sender, RoutedEventArgs e)
        {
            var login = TextBox_Login.Text;
            var password = TextBox_Password.Text;

            // Проверяем, существует ли пользователь с таким именем
            var existingUser = _context.Users.FirstOrDefault(u => u.UserName == login);

            if (existingUser != null)
            {
                MessageBox.Show("Пользователь с таким именем уже существует.");
                return;
            }

            // Создаем нового пользователя
            User newUser = new User
            {
                UserName = login,
                Password = password // Необходимо обеспечить безопасность пароля в реальном проекте
                                    // Добавьте остальные поля пользователя, если они есть
            };

            // Добавляем пользователя в базу данных
            _context.Users.Add(newUser);
            _context.SaveChanges();

            MessageBox.Show("Регистрация прошла успешно.");
        }
    }
}


