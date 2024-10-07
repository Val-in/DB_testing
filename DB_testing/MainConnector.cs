using DB_testing.Configurations;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DB_testing
{
    public class MainConnector
    {
        private SqlConnection connection;

        public async Task<bool> ConnectAsync()
        {
            bool result;
            try
            {
                connection = new SqlConnection(ConnectionString.MsSqlConnection);
                await connection.OpenAsync();
                result = true;
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public async Task DisconnectAsync()  // Изменили на Task
        {
            if (connection.State == ConnectionState.Open)
            {
                await connection.CloseAsync();
            }
        }
    }
}
