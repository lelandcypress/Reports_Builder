using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports_Builder
{
    internal class CRUD
    {
        public static void GetDailyReport(string date)
        {

            try
            {
                string connectionString = @"Data Source=localhost;Initial Catalog=TextToDB;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = new SqlCommand("sp_GetDailyReport", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@date", date+'%');

                conn.Open();
                
                using (SqlDataReader reader = cmd.ExecuteReader()) {
                    int fieldCount = reader.FieldCount;
                    while (reader.Read())
                       {
                        StringBuilder sb = new StringBuilder();

                        for(int i =0; i < fieldCount; i++)
                        {
                            sb.Append(reader[i].ToString());
                            if (i < fieldCount -1)
                            {
                                sb.Append(", ");
                            }
                        }

                        Console.WriteLine(sb.ToString());
                       }

                    
                }


                conn.Close();
            }
            catch (SqlException exxp)
            {
                Console.WriteLine(exxp.Message);
            }
        }
        

    }

}
