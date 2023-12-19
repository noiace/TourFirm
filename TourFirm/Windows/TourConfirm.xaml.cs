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
        public TourConfirm()
        {
            InitializeComponent();
        }
    }
}
