using System.Data.SQLite;
using System.Reflection;
using System.Data;

namespace CleanCode_Task9
{
    public class DataBaseContext
    {
        public DataTable GetDataTable(string hashPassport)
        {
            ArgumentNullException.ThrowIfNull(hashPassport);

            SQLiteConnection _connection = new SQLiteConnection(GetConnectionString());
            _connection.Open();

            SQLiteDataAdapter _adapter = new SQLiteDataAdapter(GetCommandString(hashPassport), _connection);

            DataTable dataTable = new DataTable();
            _adapter.Fill(dataTable);

            _connection.Close();

            return dataTable;
        }

        private string GetConnectionString() =>
            String.Format("Data Source=" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\db.sqlite");

        private string GetCommandString(string hashPassport)
        {
            ArgumentNullException.ThrowIfNull(hashPassport);

            return string.Format("select * from passports where num='{0}' limit 1;", hashPassport);
        }
    }
}