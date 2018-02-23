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

namespace WPFDataBinding.Demo
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btn_AddUsers_Click(object sender, RoutedEventArgs e)
        {
            Users obj1 = new Users();
            obj1.ShowDialog();
        }

        private void btn_AddStock_Click(object sender, RoutedEventArgs e)
        {
            Stocks obj2 = new Stocks();
            obj2.ShowDialog();

        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
