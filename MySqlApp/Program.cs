using System;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Build configuration
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfigurationRoot configuration = builder.Build();

        // Get connection string
        string connectionString = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrEmpty(connectionString))
        {
            Console.WriteLine("Connection string is null or empty.");
            return;
        }

        // Connect to database and fetch data
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            try
            {
                conn.Open();
                Console.WriteLine("Successfully connected to the database.");

                string sql = "SELECT * FROM `name`"; 
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    // Affiche les noms des colonnes
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write(reader.GetName(i) + "\t");
                    }
                    Console.WriteLine();

                    // Affiche les données
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write(reader.GetValue(i) + "\t");
                        }
                        Console.WriteLine();
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
