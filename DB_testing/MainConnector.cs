using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DB_testing
{
    public class MainConnector
    {
        private readonly string connectionString;
        private SqlConnection connection;

        public MainConnector(string connectionString)
        {
            this.connectionString = connectionString;
            connection = new SqlConnection(connectionString);
        }

        public SqlConnection GetConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                return connection;
            }
            else
            {
                throw new Exception("Подключение уже закрыто!");
            }
        }

        public void Connect()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

        public void Disconnect()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
