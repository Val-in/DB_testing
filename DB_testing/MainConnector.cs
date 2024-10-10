using System.Data;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace DB_testing
{
    public class MainConnector
    {
        private readonly string connectionString;
        private SqlConnection connection;

        // Добавляем свойство Result для проверки успешного подключения
        public bool Result { get; private set; }

        public MainConnector(string connectionString)
        {
            this.connectionString = connectionString;
            connection = new SqlConnection(connectionString);
            Result = false; // Изначально подключение не установлено
        }

        public SqlConnection GetConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                return connection;
            }
            else
            {
                throw new Exception("Подключение закрыто!");
            }
        }

        // Асинхронное подключение
        public async Task<bool> ConnectAsync()
        {
            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync();
                Result = true; // Подключение установлено
                return true;
            }
            Result = false; // Подключение уже установлено
            return false;
        }

        // Асинхронное отключение
        public async Task<bool> DisconnectAsync()
        {
            if (connection.State == ConnectionState.Open)
            {
                await connection.CloseAsync();
                Result = false; // Подключение закрыто
                return true;
            }
            return false;
        }

        // Синхронное подключение
        public void Connect()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
                Result = true; // Подключение установлено
            }
        }

        // Синхронное отключение
        public void Disconnect()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                Result = false; // Подключение закрыто
            }
        }
    }
}
