using Npgsql;
using System;

public class DatabaseHelper
{
    private string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=your_1q2w3e;Database=restaurant-menu;";

    public void ConnectToDatabase()
    {
        try
        {
            // Create a connection to the database
            using (var connection = new NpgsqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();
                Console.WriteLine("Connection successful!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Connection failed: {ex.Message}");
        }
    }
}
