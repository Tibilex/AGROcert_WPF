using AGROcert.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AGROcert.ViewModels
{
    public class AdminProfileViewModel : INotifyPropertyChanged
    {
        private string _connectionString = "Data Source = SQL8003.site4now.net,1433; Initial Catalog = db_a878c3_tibiriumtype; User Id = db_a878c3_tibiriumtype_admin; Password=tibirium1;";
        public ObservableCollection<Administrator> Administrators { get; set; }
        public string AdmName { get; set; }
        public string AdmSurname { get; set; }
        public string AdmPhone { get; set; }
        public string AdmEmail { get; set; }

        public AdminProfileViewModel()
        {
            Administrators = new ObservableCollection<Administrator>();
            GetDataInDataBase();
        }

        private void GetDataInDataBase()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("SELECT AdmName, AdmSurname, AdmPhone, AdmEmail FROM Administrators", connection);
            connection.Open();
            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    object admName = dataReader.GetValue(0);
                    object admSurname = dataReader.GetValue(1);
                    object admPhone = dataReader.GetValue(2);
                    object admEmail = dataReader.GetValue(3);
                    AdmName = admName.ToString();
                    AdmSurname = admSurname.ToString();
                    AdmPhone = admPhone.ToString();
                    AdmEmail = admEmail.ToString();
                }
            }
            dataReader.Close();
            connection.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
