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
    /// Логика взаимодействия для Methodist.xaml
    /// </summary>
    public partial class Methodist : Page
    {
        string id;
        public Methodist()
        {
            InitializeComponent();
            DataTable table = new DataTable();
            SqlCommand comm = new SqlCommand($"SELECT [Методическая разработка].Код, Преподаватели.Фамилия, Преподаватели.Имя, Преподаватели.Отчество, Дисциплины.Наименование, КТП.Наименование, [Рабочая программа].Наименование, [Методическая разработка].Олимпиады FROM ПеподавателиДисциплин JOIN Преподаватели ON ПеподавателиДисциплин.КодПреподавателей = Преподаватели.Код JOIN Дисциплины ON Дисциплины.Код = ПеподавателиДисциплин.КодДисциплин JOIN [Методическая разработка] ON [Методическая разработка].КодПреподователейДисциплин = ПеподавателиДисциплин.Код JOIN КТП ON КТП.Код = [Методическая разработка].КодКТП JOIN [Рабочая программа] ON [Рабочая программа].Код = [Методическая разработка].КодРабочейПрограммы",dataInfo.conn);
            SqlDataAdapter adapter = new SqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            adapter.Fill(table);

            DataTable teachers = new DataTable();

            teachers.Columns.Add("id", typeof(string));
            teachers.Columns.Add("fullName", typeof(string));
            teachers.Columns.Add("discipName", typeof(string));
            teachers.Columns.Add("ktp", typeof(string));
            teachers.Columns.Add("workProgramm", typeof(string));
            teachers.Columns.Add("tournoments", typeof(string));

            for (int i = 0; i < table.Rows.Count; i++)
            {
                teachers.Rows.Add(table.Rows[i][0].ToString(), table.Rows[i][1].ToString() + ' ' + table.Rows[i][2].ToString() + ' ' + table.Rows[i][3].ToString(), table.Rows[i][4].ToString(), table.Rows[i][5].ToString(), table.Rows[i][6].ToString(), table.Rows[i][7].ToString());
            }

            grid.ItemsSource = teachers.DefaultView;
        }

        private void grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            id = ((DataRowView)grid.SelectedItems[0]).Row["id"].ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dataInfo.nav(dataInfo.MainFrame, "MethodistAdd.xaml");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SqlCommand comm;
            if (id != null) {
                comm = new SqlCommand($"DELETE FROM [Методическая разработка] WHERE [Методическая разработка].Код = '{id}'", dataInfo.conn);
                comm.ExecuteNonQuery();
            }
            DataTable table = new DataTable();
            comm = new SqlCommand($"SELECT [Методическая разработка].Код, Преподаватели.Фамилия, Преподаватели.Имя, Преподаватели.Отчество, Дисциплины.Наименование, КТП.Наименование, [Рабочая программа].Наименование, [Методическая разработка].Олимпиады FROM ПеподавателиДисциплин JOIN Преподаватели ON ПеподавателиДисциплин.КодПреподавателей = Преподаватели.Код JOIN Дисциплины ON Дисциплины.Код = ПеподавателиДисциплин.КодДисциплин JOIN [Методическая разработка] ON [Методическая разработка].КодПреподователейДисциплин = ПеподавателиДисциплин.Код JOIN КТП ON КТП.Код = [Методическая разработка].КодКТП JOIN [Рабочая программа] ON [Рабочая программа].Код = [Методическая разработка].КодРабочейПрограммы", dataInfo.conn);
            SqlDataAdapter adapter = new SqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            adapter.Fill(table);

            DataTable teachers = new DataTable();

            teachers.Columns.Add("id", typeof(string));
            teachers.Columns.Add("fullName", typeof(string));
            teachers.Columns.Add("discipName", typeof(string));
            teachers.Columns.Add("ktp", typeof(string));
            teachers.Columns.Add("workProgramm", typeof(string));
            teachers.Columns.Add("tournoments", typeof(string));

            for (int i = 0; i < table.Rows.Count; i++)
            {
                teachers.Rows.Add(table.Rows[i][0].ToString(), table.Rows[i][1].ToString() + ' ' + table.Rows[i][2].ToString() + ' ' + table.Rows[i][3].ToString(), table.Rows[i][4].ToString(), table.Rows[i][5].ToString(), table.Rows[i][6].ToString(), table.Rows[i][7].ToString());
            }

            grid.ItemsSource = teachers.DefaultView;
        }
    }
}
