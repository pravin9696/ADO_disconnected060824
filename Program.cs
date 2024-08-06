using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_disconnected060824
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string conString = "Data Source=.\\sqlexpress;Initial Catalog=myDB;Integrated Security=True;TrustServerCertificate=True";

            SqlConnection con = new SqlConnection(conString);

            SqlDataAdapter adp = new SqlDataAdapter("select * from students", con);

            DataSet ds = new DataSet();

            adp.Fill(ds, "students");

            SqlCommandBuilder scb = new SqlCommandBuilder(adp);

            DataRow dr = ds.Tables["students"].NewRow();
            //dr["id"]
            dr["name"] = "xyz";
            dr[2] = 999;

            ds.Tables["students"].Rows.Add(dr);

            int n = adp.Update(ds, "students");
            if (n > 0)
            {
                Console.WriteLine("record inserted successfully");
            }
            Console.ReadKey();
        }
    }
}
