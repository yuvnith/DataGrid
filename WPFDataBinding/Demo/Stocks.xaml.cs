using System;
using System.Collections.Generic;
using System.Data;
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
using DataBase;
namespace WPFDataBinding.Demo
{
    /// <summary>
    /// Interaction logic for Stocks.xaml
    /// </summary>
    public partial class Stocks : Window
    {

        string table = "DEMO_STOCKS";
        string primarykey = "id";
        //GenericCommands GenericCommandsObject = new GenericCommands();

        DataBase.SqlCommands GenericCommandsObject = new DataBase.SqlCommands();


        public Stocks()
        {
            InitializeComponent();
            selectcmd();
        }

        private void btn_add1_Click(object sender, RoutedEventArgs e)
        {
            insert(inp_ItemName.Text, int.Parse(inp_OrderQty.Text), inp_vendor.Text);
            inp_ItemName.Text = "";
            inp_OrderQty.Text = "";
            inp_vendor.Text = "";
        }
        public void insert(String Item, int qty, String Vendor)
        {
            Queries obj = new Queries();
            String cmd = "INSERT INTO DEMO_Stocks(ItemName,OrderQuantity,Vendor) VALUES('" + Item + "','" + qty  +"','" + Vendor+"')";
            obj.other(cmd);
            selectcmd();
        }

        public void selectcmd()
        {
            DataTable dt = GenericCommandsObject.selectCmd(table);
            StocksGrid.ItemsSource = dt.DefaultView;



            //Queries obj = new Queries();
            //String cmd = "Select * from DEMO_Stocks order by id";
            //DataTable dt = obj.select(cmd);
            //StocksGrid.ItemsSource = dt.DefaultView;

        }

        public void update(String ItemName, int OrderQuantity, String Vendor, int id)
        {
            Queries obj2 = new Queries();
            String cmd = "UPDATE DEMO_Stocks SET ItemName='" + ItemName + "',OrderQuantity='" + OrderQuantity + "',Vendor='"+ Vendor + "' WHERE ID='" + id + "'";
            obj2.other(cmd);
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            var data = (StocksGrid.SelectedItem as DataRowView).Row.ItemArray;
            int id = int.Parse(data[0].ToString());
            GenericCommandsObject.update(table, data, primarykey, id);


            //var data = (StocksGrid.SelectedItem as DataRowView).Row.ItemArray;
            //string ItemName = data[1].ToString();
            //string Vendor = data[3].ToString();
            //int OrderQuantity = int.Parse(data[2].ToString());

            //int id = int.Parse(data[0].ToString());
            //update(ItemName, OrderQuantity, Vendor, id);

        }
        public void delete(int id)
        {
            Queries obj3 = new Queries();
            String cmd = "DELETE FROM DEMO_Stocks WHERE ID='" + id + "'";
            obj3.other(cmd);
            selectcmd();
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            var data = (StocksGrid.SelectedItem as DataRowView).Row.ItemArray;
            int id = int.Parse(data[0].ToString());
            GenericCommandsObject.delete(table, primarykey, data[0].ToString());
            selectcmd();

            //var data = (StocksGrid.SelectedItem as DataRowView).Row.ItemArray;
            //int id = int.Parse(data[0].ToString());
            //delete(id);
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
