using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFDataBinding.Demo
{
    public class Queries
    {
        string con = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        public DataTable select(string cmd)
        {
            using (OracleConnection oc = new OracleConnection(con))
            {
                OracleCommand ocmd = new OracleCommand();
                ocmd.CommandText = cmd;
                ocmd.Connection = oc;
                oc.Open();
                //OracleDataReader odr = ocmd.ExecuteReader();
                OracleDataAdapter oda = new OracleDataAdapter(ocmd);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                return dt;
                oc.Close();
            }
        }
        public void other(string cmd)
        {
            using (OracleConnection oc = new OracleConnection(con))
            {
                OracleCommand ocmd = new OracleCommand();
                ocmd.CommandText = cmd;
                ocmd.Connection = oc;
                oc.Open();
                int a = ocmd.ExecuteNonQuery();        
                oc.Close();
            }
        }


    }
}
