using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AddTeacherPage.xaml
    /// </summary>
    public partial class AddTeacherPage : Page
    {
        public AddTeacherPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text != "" && surname.Text != "" && fatherName.Text != "")
            {
                SqlCommand comm = new SqlCommand($"INSERT INTO Преподаватели VALUES('{surname.Text}','{name.Text}','{fatherName.Text}')", dataInfo.conn);
                comm.ExecuteNonQuery();
                dataInfo.nav(dataInfo.MainFrame, "TeachersPage.xaml");
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }
    }
}
