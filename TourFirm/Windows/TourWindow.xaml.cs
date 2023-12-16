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
        public TourWindow()
        {
            InitializeComponent();

            _context = TourDbContext.GetContext();
            _tours = _context.Tours.ToList();

            ListView_Tours.ItemsSource = _tours;
        }
    }
}
