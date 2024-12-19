using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows;

namespace observatory.code
{
    public class DatabaseHelper
    {
        /* public void ImportDB(string filePath)
         {
             try
             {
                 string connectionString = "Server=LEGION;Database=observatory;Integrated Security=True;";
                 string tableName = "your_table"; // Имя таблицы для импорта данных

                 using (SqlConnection connection = new SqlConnection(connectionString))
                 {
                     connection.Open();

                     string query = $"BULK INSERT {tableName} " +
                                    $"FROM '{filePath}' " +
                                    "WITH (FIELDTERMINATOR = ',', ROWTERMINATOR = '\\n', FIRSTROW = 2);"; // Пропустить заголовок

                     using (SqlCommand cmd = new SqlCommand(query, connection))
                     {
                         cmd.ExecuteNonQuery();
                     }
                 }

                 MessageBox.Show("Импорт выполнен успешно.");
             }
             catch (Exception ex)
             {
                 MessageBox.Show($"Ошибка импорта: {ex.Message}");
             }
         }*/

        public void ExportTablesToCsvFiles(string connectionString, string folderPath)
        {
            try
            {
                List<string> tables = GetAllTables(connectionString);

                foreach (var table in tables)
                {
                    string filePath = Path.Combine(folderPath, $"{table}.csv");

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = $"SELECT * FROM {table};";
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            using (StreamWriter writer = new StreamWriter(filePath, false, new System.Text.UTF8Encoding(true)))
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    writer.Write(reader.GetName(i) + (i < reader.FieldCount - 1 ? "," : ""));
                                }
                                writer.WriteLine();

                                while (reader.Read())
                                {
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        writer.Write($"\"{reader[i]?.ToString().Replace("\"", "\"\"")}\"" + (i < reader.FieldCount - 1 ? "," : ""));
                                    }
                                    writer.WriteLine();
                                }
                            }
                        }
                    }

                    Console.WriteLine($"Таблица {table} экспортирована в файл {filePath}");
                }

                MessageBox.Show("Экспорт всех таблиц в файлы завершен.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка экспорта таблиц: {ex.Message}");
            }
        }

        public List<string> GetAllTables(string connectionString)
        {
            List<string> tables = new List<string>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE';";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tables.Add(reader[0].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка получения таблиц: {ex.Message}");
            }

            return tables;
        }

        public void BackupDatabase(string backupFilePath)
        {
            try
            {
                string backupDirectory = Path.GetDirectoryName(backupFilePath);
                if (!Directory.Exists(backupDirectory))
                {
                    Directory.CreateDirectory(backupDirectory);
                }
                string connectionString = "Server=LEGION;Database=observatory;Integrated Security=True;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"BACKUP DATABASE observatory TO DISK = '{backupFilePath}' WITH FORMAT;";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show(
                    $"Бэкап выполнен успешно. Файл сохранен в: {backupFilePath}",
                    "Успех",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка создания бэкапа: {ex.Message}",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        public void RestoreDatabase(string backupFilePath)
        {
            try
            {
                string connectionString = "Server=LEGION;Database=master;Integrated Security=True;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string setSingleUserQuery = @"
                ALTER DATABASE observatory
                SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";

                    using (SqlCommand setSingleUserCmd = new SqlCommand(setSingleUserQuery, connection))
                    {
                        setSingleUserCmd.ExecuteNonQuery();
                    }
                    string restoreQuery = $"RESTORE DATABASE observatory FROM DISK = '{backupFilePath}' WITH REPLACE;";
                    using (SqlCommand restoreCmd = new SqlCommand(restoreQuery, connection))
                    {
                        restoreCmd.ExecuteNonQuery();
                    }
                    string setMultiUserQuery = @"
                ALTER DATABASE observatory
                SET MULTI_USER;";

                    using (SqlCommand setMultiUserCmd = new SqlCommand(setMultiUserQuery, connection))
                    {
                        setMultiUserCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Восстановление выполнено успешно.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка восстановления: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
