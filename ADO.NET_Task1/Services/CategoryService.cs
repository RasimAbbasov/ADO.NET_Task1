using ADO.NET_Task1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task1.Services
{
    internal class CategoryService
    {
        const string connection = "Server=DESKTOP-Q262GML\\SQLEXPRESS01;Database=ProductManagementDB;Trusted_Connection=True;";
        public void Create(Category category)
        {
            using var sqlConnection = GetConnection(connection);
            sqlConnection.Open();
            string query = "INSERT INTO Products VALUES(@Name)";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Name", category.Name);
            sqlCommand.ExecuteNonQuery();
        }
        public List<Category> ReadAll()
        {
            List<Category> categories = new List<Category>();
            using var sqlConnection = GetConnection(connection);
            sqlConnection.Open();
            string query = "SELECT * FROM Categories";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    int id = (int)reader.GetValue(0);
                    string name = (string)reader.GetValue(1);
                    categories.Add(new() { Id = id, Name = name });
                }
                return categories;
            }
            else
                Console.WriteLine("Table has no rows");
            return categories;
        }
        public void UpdateById(int id,Category category)
        {
            using var sqlConnection = GetConnection(connection);
            sqlConnection.Open();
            string query = "UPDATE Categories SET Name=@Name WHERE Id=@Id";
            SqlCommand sqlCommand = new SqlCommand(@query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Name", category.Name);
            sqlCommand.Parameters.AddWithValue("@Id", id);
            if(sqlCommand.ExecuteNonQuery()>0)
                Console.WriteLine("Updated");
            else
                Console.WriteLine("Invalid progress");  
        }
        public void DeleteById(int id)
        {
            using var sqlConnection = GetConnection(connection);
            sqlConnection.Open();
            string query = "DELETE FROM Categories WHERE Id=@Id";
            SqlCommand sqlCommand = new SqlCommand(@query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Id", id);
            if (sqlCommand.ExecuteNonQuery() > 0)
                Console.WriteLine("Row is deleted!");
            else
                Console.WriteLine("Wrong id!");
        }
        public static SqlConnection GetConnection(string connection)
        {
            return new SqlConnection(connection);
        }
    }
}
