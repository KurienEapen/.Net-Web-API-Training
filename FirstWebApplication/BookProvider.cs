using FirstWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FirstWebApplication
{
    public class BookProvider
    {
        private readonly string _connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        private static BookEntity ToEntity(IDataRecord reader)
        {
            return new BookEntity
            {
                Id = Convert.ToInt32(reader["Id"]),
                ReferenceId = reader["ReferenceId"].ToString(),
                Name = reader["Name"].ToString(),
                Author = reader["Author"].ToString(),
                Genre = reader["Genre"].ToString(), 
                Price= Convert.ToSingle(reader["Price"])
            };
        }

        public IEnumerable<BookEntity> GetAllBooks()
        {
            var res = new List<BookEntity>();
            using (var conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    var command = new SqlCommand("Select * from Books ", conn);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        res.Add(ToEntity(reader));
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
                finally
                {
                    conn.Close();
                }
            }
            return res;

        }

        public bool AddDevice(BookEntity entity)
        {
            var rowsAffected = 0;
            using (var conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    var command = new SqlCommand("Select count(*) from Books where Name = @name ", conn);
                    command.Parameters.AddWithValue("@name", entity.Name);
                    rowsAffected = Convert.ToInt32(command.ExecuteScalar());
                    if (rowsAffected <= 0)
                    {
                        command = new SqlCommand("Insert into Books (Name ,Author ,Genre ,Price) values (@Name ,@Author ,@Genre ,@Price);", conn);
                        command.Parameters.AddWithValue("@Name", entity.Name);
                        command.Parameters.AddWithValue("@Author", entity.Author);
                        command.Parameters.AddWithValue("@Genre", entity.Genre);
                        command.Parameters.AddWithValue("@Price", entity.Price);
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
                finally
                {
                    conn.Close();
                }
                return  rowsAffected > 0;
            }
        }
    }

    
}