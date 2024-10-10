namespace DB_testing.Configurations;

public static class ConnectionString
{
    public static string MsSqlConnection => @"Server=localhost\SQLEXPRESS02;Database=testing;Trusted_Connection=True;TrustServerCertificate=True;";
    //Server=localhost\SQLEXPRESS02;Database=testing;Trusted_Connection=True;TrustServerCertificate=True;
}
