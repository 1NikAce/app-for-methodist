using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Логика взаимодействия для MethodistAdd.xaml
    /// </summary>
    public partial class MethodistAdd : Page
    {
        public MethodistAdd()
        {
            InitializeComponent();
            DataTable table = new DataTable();
            SqlCommand comm = new SqlCommand($"SELECT ПеподавателиДисциплин.Код, Преподаватели.Фамилия, Преподаватели.Имя, Преподаватели.Отчество, Дисциплины.Наименование FROM ПеподавателиДисциплин JOIN Дисциплины ON ПеподавателиДисциплин.КодДисциплин = Дисциплины.код JOIN Преподаватели ON Преподаватели.Код = ПеподавателиДисциплин.КодПреподавателей", dataInfo.conn);
            SqlDataAdapter adapter = new SqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            adapter.Fill(table);

            DataTable editedTable = new DataTable();
            editedTable.Columns.Add("id", typeof(int));
            editedTable.Columns.Add("teacher", typeof(string));

            for (int i = 0; i < table.Rows.Count; i++)
            {
                editedTable.Rows.Add(table.Rows[i][0].ToString(), table.Rows[i][1].ToString() + ' ' + table.Rows[i][2].ToString() + ' ' + table.Rows[i][3].ToString() + ' ' + table.Rows[i][4].ToString());
            }

            prepodBox.ItemsSource = editedTable.DefaultView;
            prepodBox.DisplayMemberPath = "teacher";
            prepodBox.SelectedValuePath = "id";
            prepodBox.SelectedIndex = 0;

            table = new DataTable();
            comm = new SqlCommand($"SELECT КТП.Код, КТП.Наименование FROM КТП", dataInfo.conn);
            adapter = new SqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            adapter.Fill(table);

            editedTable = new DataTable();
            editedTable.Columns.Add("id", typeof(int));
            editedTable.Columns.Add("ktp", typeof(string));

            for (int i = 0; i < table.Rows.Count; i++)
            {
                editedTable.Rows.Add(table.Rows[i][0].ToString(), table.Rows[i][1].ToString());
            }

            ktpBox.ItemsSource = editedTable.DefaultView;
            ktpBox.DisplayMemberPath = "ktp";
            ktpBox.SelectedValuePath = "id";
            ktpBox.SelectedIndex = 0;

            olimpBox.ItemsSource = editedTable.DefaultView;
            olimpBox.DisplayMemberPath = "ktp";
            olimpBox.SelectedValuePath = "id";
            olimpBox.SelectedIndex = 0;

            workProgBox.ItemsSource = editedTable.DefaultView;
            workProgBox.DisplayMemberPath = "ktp";
            workProgBox.SelectedValuePath = "id";
            workProgBox.SelectedIndex = 0;
        }

        private void teacher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //try
            //{
            //    DataTable table = new DataTable();
            //    SqlCommand comm = new SqlCommand($"SELECT Код, Наименование WHERE ", dataInfo.conn);
            //    SqlDataAdapter adapter = new SqlDataAdapter(comm);
            //    comm.ExecuteNonQuery();
            //    adapter.Fill(table);

            //    DataTable editedTable = new DataTable();
            //    editedTable.Columns.Add("id", typeof(int));
            //    editedTable.Columns.Add("Naimenovanie", typeof(string));

            //    for (int i = 0; i < table.Rows.Count; i++)
            //    {
            //        editedTable.Rows.Add(table.Rows[i][0].ToString(), table.Rows[i][1].ToString());
            //    }

            //    discipBox.ItemsSource = editedTable.DefaultView;
            //    discipBox.DisplayMemberPath = "Naimenovanie";
            //    discipBox.SelectedValuePath = "id";
            //    discipBox.SelectedIndex = 0;
            //}
            //catch 
            //{
            //    return;
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand comm = new SqlCommand($"INSERT INTO [Методическая разработка] VALUES('{1}','{prepodBox.SelectedValue.ToString()}','{ktpBox.SelectedValue.ToString()}','{workProgBox.SelectedValue.ToString()}','{olimpBox.Text}')",dataInfo.conn);
            comm.ExecuteNonQuery();
            dataInfo.nav(dataInfo.MainFrame, "Methodist.xaml");
        }
    }
}
