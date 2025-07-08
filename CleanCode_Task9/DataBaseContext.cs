using System.Data.SQLite;
using System.Reflection;
using System.Data;

namespace CleanCode_Task9
{
    public class DataBaseContext
    {
        private SQLiteConnection _connection;
        private SQLiteDataAdapter _adapter;

        public DataTable GetDataTable(string hashPassport)
        {
            _connection = new SQLiteConnection(GetConnectionString());
            _connection.Open();

            _adapter = new SQLiteDataAdapter(GetCommandString(hashPassport), _connection);

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