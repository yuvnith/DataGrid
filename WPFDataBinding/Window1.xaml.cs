using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
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

namespace WPFDataBinding
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string con = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        public ObservableCollection<Student> StuList;
        
        public Window1()
        {
            InitializeComponent();
            StuList = new ObservableCollection<Student>();          
            selectcmd();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Student a = new Student();
            a.Name = Tb1.Text;
            a.Age = Int32.Parse(Tb2.Text);
            StuList.Add(a);

            Tb1.Text = "";
            Tb2.Text = "";

            insertcmd(a.Name,a.Age);



        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void inp_delete_Click(object sender, RoutedEventArgs e)
        {
            var data = (dg.SelectedItem as DataRowView).Row.ItemArray;
            string Name = data[0].ToString();
           
            deletecmd(Name);
            //StuList.RemoveAt(index);
            
        }

        private void btn_close__Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void selectcmd()
        {
            using (OracleConnection oc = new OracleConnection(con))
            {
                OracleCommand ocmd = new OracleCommand();
                ocmd.CommandText = "Select * from STUDENT";
                ocmd.Connection = oc;
                oc.Open();
                //OracleDataReader odr = ocmd.ExecuteReader();
                OracleDataAdapter oda = new OracleDataAdapter(ocmd);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                dg.ItemsSource = dt.DefaultView;
                //DataContext = dt;
                //odr.Read();
                //MessageBox.Show(odr.GetString(0));
                oc.Close();
            }
        }
        public void createcmd()
        {
            using (OracleConnection oc = new OracleConnection(con))
            {
                OracleCommand ocmd = new OracleCommand();
                ocmd.CommandText = "CREATE TABLE STUDENT(Name varchar(255),Age int)";
                ocmd.Connection = oc;
                oc.Open();
                int a = ocmd.ExecuteNonQuery();
                MessageBox.Show(a + "");
                oc.Close();
            }
        }


        public void deletecmd(String name)
        {
            using (OracleConnection oc = new OracleConnection(con))
            {
                OracleCommand ocmd = new OracleCommand();
                ocmd.CommandText = "DELETE FROM STUDENT WHERE Name='"+name+"'";
                ocmd.Connection = oc;
                oc.Open();
                int a = ocmd.ExecuteNonQuery();
                MessageBox.Show(a + "");
                oc.Close();
            }
        }




        public void insertcmd(String name,int age)
        {
            using (OracleConnection oc = new OracleConnection(con))
            {
                OracleCommand ocmd = new OracleCommand();
                ocmd.CommandText = "INSERT INTO STUDENT(Name,Age) VALUES('" + name + "','" + age + "')";
                ocmd.Connection = oc;
                oc.Open();
                int a = ocmd.ExecuteNonQuery();
                MessageBox.Show(a + "");
                oc.Close();
            }
        }


        public void updatecmd(String name, int age)
        {
            using (OracleConnection oc = new OracleConnection(con))
            {
                OracleCommand ocmd = new OracleCommand();
                ocmd.CommandText = "UPDATE STUDENT SET Name='"+name+"',Age='"+age+"' WHERE Name='"+name+"'";
                ocmd.Connection = oc;
                oc.Open();
                int a = ocmd.ExecuteNonQuery();
                MessageBox.Show(a + "");
                oc.Close();
            }
        }

        private void btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            selectcmd();
        }

        private void btn_update__Click(object sender, RoutedEventArgs e)
        {
            var data = (dg.SelectedItem as DataRowView).Row.ItemArray;
            string Name = data[0].ToString();
            int age  = int.Parse(data[1].ToString());
            updatecmd(Name,age);
        }
    }
}
