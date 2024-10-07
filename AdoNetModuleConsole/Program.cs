using DB_testing;

namespace AdoNetModuleConsole
{
    public class Program
    {
        static async Task Main(string[] args)  // Сделали метод async
        {
            var connector = new MainConnector();

            var result = await connector.ConnectAsync();  // Добавили await

            if (result)
            {
                Console.WriteLine("Подключено успешно!");
            }
            else
            {
                Console.WriteLine("Ошибка подключения!");
            }

            // Отключаемся от базы данных
            await connector.DisconnectAsync();  // Добавили корректный вызов DisconnectAsync

            Console.ReadKey();
        }
    }
}