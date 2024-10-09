using DB_testing;
using System.Data;

namespace AdoNetModuleConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "your_connection_string_here"; // Замените на вашу строку подключения
            var connector = new MainConnector(connectionString);

            try
            {
                connector.Connect();
                Console.WriteLine("Подключено успешно!");

                var db = new DbExecutor(connector);
                var tableName = "NetworkUser";

                Console.WriteLine("Получаем данные таблицы " + tableName);
                var data = db.SelectAll(tableName);

                Console.WriteLine("Количество строк в " + tableName + ": " + data.Rows.Count);

                // Дополнительный вывод данных (необязательно)
                foreach (DataRow row in data.Rows)
                {
                    Console.WriteLine($"ID: {row["Id"]}, Name: {row["Name"]}, Login: {row["Login"]}");
                }

                connector.Disconnect();
                Console.WriteLine("Отключено от БД!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }
}