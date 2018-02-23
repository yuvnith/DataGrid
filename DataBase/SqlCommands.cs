using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    class SqlCommands
    {

        public DataTable selectCmd(String table)
        {
            Queries obj = new Queries();
            String cmd = "Select * from " + table;
            DataTable dt = obj.select(cmd);
            return dt;
        }


        public DataTable columns(String table)
        {
            Queries obj = new Queries();
            String cmd = " select COLUMN_NAME from ALL_TAB_COLUMNS where TABLE_NAME = '" + table + "'";
            DataTable dt = obj.select(cmd);
            return dt;
        }


        public void insertCmd()
        {

        }

        public void update(String table, object[] array, String primarykey, int value)
        {
            Queries obj = new Queries();


            DataTable dt2 = columns(table);
            string[] array2 = dt2.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray();


            //UPDATE Customers
            //SET ContactName = 'Alfred Schmidt', City = 'Frankfurt'
            //WHERE CustomerID = 1;

            String cmd = "";

            if (dt2.Rows.Count == array.Length)
            {
                cmd = "update " + table + " set ";

                for (int i = 0; i < array.Length; i++)
                {
                    if (array2[i].ToString().ToUpper() != primarykey.ToUpper())
                    {
                        cmd += array2[i];
                        cmd += "=";
                        cmd += "'";
                        cmd += array[i];
                        cmd += "' ";
                        if (i != array.Length - 1)
                            cmd += ",";

                    }

                }


                cmd += " Where " + primarykey;
                cmd += "=";

                cmd += value.ToString();


            }


            obj.other(cmd);


        }

        public void delete(String table, String column, String value)
        {
            Queries obj = new Queries();
            String cmd = "Delete from " + table + " Where " + column + " = " + value;
            obj.other(cmd);

        }




    }
}
