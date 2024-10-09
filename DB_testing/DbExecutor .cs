using System.Data;
using Microsoft.Data.SqlClient;

namespace DB_testing
{
    public class DbExecutor
    {
        private readonly MainConnector connector;

        public DbExecutor(MainConnector connector)
        {
            this.connector = connector;
        }

        public DataTable SelectAll(string table)
        {
            var selectCommandText = "SELECT * FROM " + table;
            using (var adapter = new SqlDataAdapter(selectCommandText, connector.GetConnection()))
            {
                var ds = new DataSet();
                adapter.Fill(ds);
                return ds.Tables[0]; // Возвращаем первую таблицу из DataSet
            }
        }
    }
}
