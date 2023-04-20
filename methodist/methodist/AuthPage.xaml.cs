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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace methodist
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        int noValidPassword;
        public AuthPage()
        {
            InitializeComponent();
            try
            {
                dataInfo.conn = new SqlConnection("Server=localhost;Database=GoulSSS;Trusted_Connection=True;");
                if (dataInfo.conn.State == System.Data.ConnectionState.Closed) dataInfo.conn.Open();
            }
            catch
            {
                dataInfo.conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=GoulSSS;Trusted_Connection=True;");
                if (dataInfo.conn.State == System.Data.ConnectionState.Closed) dataInfo.conn.Open();
            }
            noValidPassword = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (login.Text != "" && pass.Text != "") 
            {
                if (dataInfo.conn.State == ConnectionState.Closed) dataInfo.conn.Open();
                DataTable table = new DataTable();
                SqlCommand comm = new SqlCommand($"SELECT * FROM Методист WHERE Логин = '{login.Text}' AND Пароль = '{pass.Text}'", dataInfo.conn);
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                comm.ExecuteNonQuery();
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    dataInfo.nav(dataInfo.MainFrame, "MainMenu.xaml");
                }
                else
                {
                    if (noValidPassword == 2) System.Environment.Exit(0);
                    else noValidPassword++;
                }
            }
        }
    }
}
