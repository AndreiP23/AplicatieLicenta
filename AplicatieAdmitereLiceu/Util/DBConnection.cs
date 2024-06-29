using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Formats.Asn1;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using pocketbase.net.Models.Helpers;


namespace LicentaNou2.Util
{
    public interface IDBConnection
    {
        void MapDataModel<T>(IDataRecord record, T item) where T : new();
        Task<T> ExecuteQuerySingle<T>(string query, params SQLiteParameter[] parameters) where T : new();
        Task<List<T>> ExecuteQueryWithPram<T>(string query, params SQLiteParameter[] parameters) where T : new();
        int ExecuteScalarInt(string query, params SQLiteParameter[] parameters);
        double ExecuteScalarDouble(string query, params SQLiteParameter[] parameters);
        Task<List<T>> ExecuteQueryV2<T>(string query, params SQLiteParameter[] parameters);
    }
    public class DBConnection : IDBConnection
    {
        private static string dbAdress = @"Data Source = D:\AplicatieLicentaGit\Aplicatie-Licenta\AplicatieAdmitereLiceuApiPocketbase\pb_data\data.db";
        private static string dbAdressIP = @"http://127.0.0.1:8090/";
        public void MapDataModel<T>(IDataRecord record, T item) where T : new()
        {
            for (int i = 0; i < record.FieldCount; i++)
            {
                string propertyName = record.GetName(i);
                object value = record[i];
                PropertyInfo property = typeof(T).GetProperty(propertyName);
                if (property != null)
                {
                    if (value != DBNull.Value)
                    {
                        Type propertyType = property.PropertyType;
                        value = Convert.ChangeType(value, propertyType);
                        property.SetValue(item, value);
                    }
                    else
                    {
                        // Handle DBNull.Value according to your logic, e.g., set a default value
                        // property.SetValue(item, DefaultValueForType(property.PropertyType));
                    }
                }
            }
        }
        public async Task<T> ExecuteQuerySingle<T>(string query, params SQLiteParameter[] parameters) where T : new()
        {
            string connectionString = dbAdress;
            T resultItem = new T();

            await using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                await connection.OpenAsync();

                await using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddRange(parameters);

                    using (DbDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            MapDataModel(reader, resultItem);
                        }
                    }
                }

                connection.Close();
            }

            return resultItem;
        }
        public async Task<List<T>> ExecuteQueryWithPram<T>(string query, params SQLiteParameter[] parameters) where T : new()
        {
            string connectionString = dbAdress;
            List<T> resultList = new List<T>();

            await using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.OpenAsync();

                await using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddRange(parameters);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            T item = new T();
                            MapDataModel(reader, item);
                            resultList.Add(item);
                        }
                    }
                }

                connection.Close();
            }

            return resultList;
        }
        public int ExecuteScalarInt(string query, params SQLiteParameter[] parameters)
        {
            string connectionString = dbAdress;
            int result = 0;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddRange(parameters);

                    // ExecuteScalar returns the first column of the first row as an object
                    var scalarResult = command.ExecuteScalar();

                    // Check if the result is not null and convert it to int
                    if (scalarResult != null && int.TryParse(scalarResult.ToString(), out result))
                    {
                        // Blank
                    }
                    else
                    {
                        throw new Exception("Nu s-a putut converti sau nu exista in baza de date.");
                    }
                }

                connection.Close();
            }

            return result;
        }
        public double ExecuteScalarDouble(string query, params SQLiteParameter[] parameters)
        {
            string connectionString = dbAdress;
            double result = 0;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddRange(parameters);

                    // ExecuteScalar returns the first column of the first row as an object
                    var scalarResult = command.ExecuteScalar();

                    // Check if the result is not null and convert it to int
                    if (scalarResult != null && double.TryParse(scalarResult.ToString(), out result))
                    {
                        // Blank
                    }
                    else
                    {
                        throw new Exception("Nu s-a putut converti sau nu exista in baza de date.");
                    }
                }

                connection.Close();
            }

            return result;
        }
        public async Task<List<T>> ExecuteQueryV2<T>(string query, params SQLiteParameter[] parameters)
        {
            string connectionString = dbAdress;
            List<T> resultList = new List<T>();

            try
            {
                await using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                   await connection.OpenAsync();

                    await using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // Add parameters to the command
                        command.Parameters.AddRange(parameters);

                        await using (DbDataReader baseReader = await command.ExecuteReaderAsync())
                        {
                            SQLiteDataReader reader = (SQLiteDataReader)baseReader;
                            while (await reader.ReadAsync())
                            {
                                T resultItem;

                                if (typeof(T).IsPrimitive || typeof(T) == typeof(string))
                                {
                                    // Handle primitive types and strings
                                    object value = reader[0];
                                    resultItem = (T)Convert.ChangeType(value, typeof(T));
                                }
                                else
                                {
                                    // Handle other reference types
                                    resultItem = default(T);
                                    // MapDataModel(reader, resultItem);
                                }

                                resultList.Add(resultItem);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (log, throw, etc.)
                Console.WriteLine($"Error: {ex.Message}");
            }

            return resultList;
        }

    }

}

