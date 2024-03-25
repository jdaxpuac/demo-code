using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace demo_library.Sql
{
    public class DBStoreSqlCommand
    {
        public SqlConnection Connectiondb(string connString = "")
        {
            try
            {
                SqlConnection connection;
                if (connString != "") {
                    connection = new SqlConnection(connString);
                } else {
                    connection = new SqlConnection(@"\Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=aspnet-MvcMovie;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\Temp.mdf");
                }                
                connection.Open();
                return connection;                                
            }
            catch
            {
                throw;
            }
        }

        public void InsertItem(Item itm)
        {
            try
            {
                string query = "INSERT INTO Item (name, description) VALUES (@item, @description);";
                using (SqlConnection con = Connectiondb())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@item", itm.name);
                    cmd.Parameters.AddWithValue("@description", itm.description);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
        }

        public Item GetItem(int id)
        {
            Item itmFound;
            try
            {
                string query = $"SELECT id, name, description FROM Item WHERE id = {id}";
                using (SqlConnection con = Connectiondb(""))
                using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                using (DataTable dta = new DataTable())
                {
                    sda.Fill(dta);
                    var rowa = dta.Rows[0];
                    itmFound = new Item()
                    {
                        id = int.Parse(rowa[0].ToString()),
                        name = rowa[1].ToString(),
                        description = rowa[2].ToString()
                    };
                    con.Close();
                }
                return itmFound;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
