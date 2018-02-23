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
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class Users : Window
    {
        string _table = "DEMO_USERS";
        string primarykey = "id";
        //GenericCommands SqlCommandsobj = new GenericCommands();


        DataBase.SqlCommands SqlCommandsobj = new DataBase.SqlCommands();




        public Users()
        {
            InitializeComponent();
            selectcmd();
        }
        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            insert(inp_name.Text,int.Parse(inp_age.Text));
            inp_age.Text = "";
            inp_name.Text = "";
        }

        public void selectcmd()
        {
            DataTable dt= SqlCommandsobj.selectCmd(_table);
            dg.ItemsSource = dt.DefaultView;
            //Queries obj = new Queries();
            //String cmd = "Select * from DEMO_USERS order by id";
            //DataTable dt = obj.select(cmd);
            //dg.ItemsSource = dt.DefaultView;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            selectcmd();

        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            var data = (dg.SelectedItem as DataRowView).Row.ItemArray;
            int value = int.Parse(data[0].ToString());
            SqlCommandsobj.update(_table, data , primarykey, value);
            





            //var data = (dg.SelectedItem as DataRowView).Row.ItemArray;
            //string Name = data[1].ToString();
            //int age = int.Parse(data[2].ToString());
            //int id = int.Parse(data[0].ToString());
            //update(Name, age, id);
        }

        public void insert(String name, int age)
        {
            Queries obj = new Queries();
            String cmd = "INSERT INTO DEMO_USERS(NAME,AGE) VALUES('" + name + "','" + age + "')";
            obj.other(cmd);
            selectcmd();
        }
        //public void update(String name, int age,int id)
        //{
        //    Queries obj2 = new Queries();
        //    String cmd = "UPDATE demo_users SET Name='" + name + "',Age='" + age + "' WHERE ID='" + id+"'" ;
        //    obj2.other(cmd);
        //}
        //public void delete( int id)
        //{
        //    Queries obj3 = new Queries();
        //    String cmd = "DELETE FROM demo_users WHERE ID='" + id + "'";
        //    obj3.other(cmd);
        //    selectcmd();
        //}

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            var data = (dg.SelectedItem as DataRowView).Row.ItemArray;
            int id = int.Parse(data[0].ToString());
            SqlCommandsobj.delete(_table, primarykey, data[0].ToString());
        }
    }
    public class Param
    {
        String name { get; set; }
        int age { get; set; }
    }
}
