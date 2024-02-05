using System.Data.SqlClient;

namespace SistemaIntegrado.Adapter.SQL
{
    public abstract class BaseDeDatos
    {
        private string _connectionString;
        protected SqlConnection _sqlConnection;

        public BaseDeDatos(string server, string baseDeDatos)
        {
            _connectionString = $"Data Source={server}; Initial Catalog={baseDeDatos}; Integrated Security=true";
        }

        public void Connect()
        {
            _sqlConnection = new SqlConnection(_connectionString);
            _sqlConnection.Open();
        }

        public void Close()
        {
            if(_sqlConnection != null && _sqlConnection.State == System.Data.ConnectionState.Open)
                _sqlConnection.Close();
        }
    }
}
