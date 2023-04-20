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
    /// Логика взаимодействия для TeacherEdit.xaml
    /// </summary>
    public partial class TeacherEdit : Page
    {
        public TeacherEdit()
        {
            InitializeComponent();
            DataTable table = new DataTable();
            dataInfo.addToTheTable(table, $"SELECT Наименование FROM ПеподавателиДисциплин JOIN Дисциплины ON ПеподавателиДисциплин.КодДисциплин = Дисциплины.Код WHERE ПеподавателиДисциплин.КодПреподавателей = '{dataInfo.idTeacher}'",dataInfo.conn);

            grid.ItemsSource = table.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (disciplineTextBox.Text != "") 
            {
                SqlCommand comm = new SqlCommand($"SELECT Код FROM Дисциплины WHERE Наименование = '{disciplineTextBox.Text}'",dataInfo.conn);
                if (Convert.ToString(comm.ExecuteScalar()) != "")
                {
                    comm = new SqlCommand($"INSERT INTO ПеподавателиДисциплин VALUES('{dataInfo.idTeacher}','{Convert.ToString(comm.ExecuteScalar())}')", dataInfo.conn);
                    comm.ExecuteNonQuery();

                }
                else 
                {
                    comm = new SqlCommand($"INSERT INTO Дисциплины VALUES('{disciplineTextBox.Text}')",dataInfo.conn);
                    comm.ExecuteNonQuery();
                    comm = new SqlCommand($"SELECT MAX(Код) FROM Дисциплины",dataInfo.conn);
                    string idDiscipline = Convert.ToString(comm.ExecuteScalar());
                    comm = new SqlCommand($"INSERT INTO ПеподавателиДисциплин VALUES('{dataInfo.idTeacher}','{idDiscipline}')", dataInfo.conn);
                    comm.ExecuteNonQuery();
                }
            }
            DataTable table = new DataTable();
            dataInfo.addToTheTable(table, $"SELECT Наименование FROM ПеподавателиДисциплин JOIN Дисциплины ON ПеподавателиДисциплин.КодДисциплин = Дисциплины.Код WHERE ПеподавателиДисциплин.КодПреподавателей = '{dataInfo.idTeacher}'", dataInfo.conn);

            grid.ItemsSource = table.DefaultView;
        }
    }
}
