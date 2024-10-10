using DB_testing;
using DB_testing.Configurations;
using System.Data;

namespace AdoNetModuleConsole
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var connector = new MainConnector(ConnectionString.MsSqlConnection);

            // Подключаемся к базе данных
            await connector.ConnectAsync();

            var data = new DataTable();

            // Проверяем результат подключения через свойство connector.Result
            if (connector.Result)
            {
                Console.WriteLine("Подключено успешно!");

                var db = new DbExecutor(connector);

                var tablename = "NetworkUser";

                Console.WriteLine("Получаем данные таблицы " + tablename);

                data = db.SelectAll(tablename);

                Console.WriteLine("Количество строк в " + tablename + ": " + data.Rows.Count);

                Console.WriteLine("Отключаем БД!");
                await connector.DisconnectAsync();

                // Попробуем подключиться снова
                await connector.ConnectAsync();

                if (connector.Result)
                {
                    Console.WriteLine("Количество строк в " + tablename + ": " + data.Rows.Count);
                }

            }
            else
            {
                Console.WriteLine("Ошибка подключения!");
            }

            Console.ReadKey();
        }
    }
}