using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace methodist
{
    internal class dataInfo
    {
        public static SqlConnection conn { get; set; }
        public static Frame MainFrame;
        public static string idTeacher;

        public static void nav(Frame frame, string framePath)
        {
            Uri uri = new Uri(framePath, UriKind.RelativeOrAbsolute);
            frame.NavigationService.Navigate(uri);
        }

        public static bool authFunc(string sqlQuery, SqlConnection conn)
        {
            DataTable user = new DataTable();
            addToTheTable(user, sqlQuery, conn);

            if (user.Rows.Count > 0)
            {
                //dataInfo.idACC = Convert.ToInt32(user.Rows[0].ItemArray[0].ToString());

                //SqlCommand comm = new SqlCommand($"SELECT id FROM Emp WHERE idACC = '{dataInfo.idACC}'", dataInfo.conn);

                //dataInfo.idEmp = Convert.ToInt32(comm.ExecuteScalar());

                return true;
            }
            else return false;
        }

        public static DataTable addToTheTable(DataTable table, string sqlQuery, SqlConnection conn)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            command.ExecuteNonQuery();
            adapter.Fill(table);
            return table;
        }
    }
}
