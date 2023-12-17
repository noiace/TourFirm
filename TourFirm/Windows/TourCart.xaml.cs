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

namespace TourFirm.Windows
{
    /// <summary>
    /// Логика взаимодействия для TourCart.xaml
    /// </summary>
    public partial class TourCart : Window
    {
        public TourCart()
        {
            InitializeComponent();
        }
        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            TourWindow tw = new TourWindow();
            tw.Show();
            this.Close();
        }
    }
}
