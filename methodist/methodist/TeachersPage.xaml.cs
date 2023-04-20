using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace methodist
{
    /// <summary>
    /// Логика взаимодействия для TeachersPage.xaml
    /// </summary>
    public partial class TeachersPage : Page
    {
        string idTeacher;
        public TeachersPage()
        {
            InitializeComponent();

            DataTable table = new DataTable();
            SqlCommand comm = new SqlCommand($"SELECT Код, Фамилия, Имя, Отчество FROM Преподаватели",dataInfo.conn);
            SqlDataAdapter adapter = new SqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            adapter.Fill(table);

            DataTable teachers = new DataTable();

            teachers.Columns.Add("id", typeof(string));
            teachers.Columns.Add("fullName", typeof(string));

            for (int i = 0; i< table.Rows.Count; i++) {
                teachers.Rows.Add(table.Rows[i][0].ToString(), table.Rows[i][1].ToString() + ' ' + table.Rows[i][2].ToString() + ' ' + table.Rows[i][3].ToString());
            }

            TeacherGrid.ItemsSource = teachers.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dataInfo.nav(dataInfo.MainFrame, "AddTeacherPage.xaml");
        }

        private void TeacherGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            dataInfo.idTeacher = ((DataRowView)TeacherGrid.SelectedItems[0]).Row["id"].ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (dataInfo.idTeacher != null)
            {
                dataInfo.nav(dataInfo.MainFrame, "TeacherEdit.xaml");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SqlCommand comm;
            if (dataInfo.idTeacher != null)
            {
                comm = new SqlCommand($"DELETE FROM ПеподавателиДисциплин WHERE ПеподавателиДисциплин.КодПреподавателей = '{dataInfo.idTeacher}'", dataInfo.conn);
                comm.ExecuteNonQuery();
                comm = new SqlCommand($"DELETE FROM Преподаватели WHERE Преподаватели.Код = '{dataInfo.idTeacher}'",dataInfo.conn);
                comm.ExecuteNonQuery();
            }

            DataTable table = new DataTable();
            comm = new SqlCommand($"SELECT Код, Фамилия, Имя, Отчество FROM Преподаватели", dataInfo.conn);
            SqlDataAdapter adapter = new SqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            adapter.Fill(table);

            DataTable teachers = new DataTable();

            teachers.Columns.Add("id", typeof(string));
            teachers.Columns.Add("fullName", typeof(string));

            for (int i = 0; i < table.Rows.Count; i++)
            {
                teachers.Rows.Add(table.Rows[i][0].ToString(), table.Rows[i][1].ToString() + ' ' + table.Rows[i][2].ToString() + ' ' + table.Rows[i][3].ToString());
            }

            TeacherGrid.ItemsSource = teachers.DefaultView;
        }
    }
}
