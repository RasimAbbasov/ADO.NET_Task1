using ADO.NET_Task1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task1.Services
{
    internal class ProductService
    {
        const string connection = "Server=DESKTOP-Q262GML\\SQLEXPRESS01;Database=ProductManagementDB;Trusted_Connection=True;";
        public void Create(Product product) 
        {
            using var sqlConnection = GetConnection(connection);
            sqlConnection.Open();
            string query = "INSERT INTO Products VALUES(@Name,@Price)";
            SqlCommand sqlCommand= new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Name", product.Name);
            sqlCommand.Parameters.AddWithValue("@Price", product.Price);
            sqlCommand.ExecuteNonQuery();
        }
        public List<Product> ReadAll() 
        {
            List<Product> products = new List<Product>();
            using var sqlConnection = GetConnection(connection);
            sqlConnection.Open();
            string query = "SELECT * FROM Products";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows) 
            {
                while (reader.Read()) 
                {

                 int id =(int)reader.GetValue(0);
                 string name =(string)reader.GetValue(1);
                 decimal price =(decimal)reader.GetValue(2);
                    products.Add(new() { Id = id, Name = name, Price = price });
                }
                return products;
            }
            else
                Console.WriteLine("Table has no rows");
                return products;
        }
        public void UpdateById(Product product) 
        {
            using var sqlConnection = GetConnection(connection);
            sqlConnection.Open();
            string query = "UPDATE Products SET Name=@Name,Price=@Price WHERE Id=@Id";
            SqlCommand sqlCommand = new SqlCommand(@query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Name", product.Name);
            sqlCommand.Parameters.AddWithValue("@Price", product.Price);
            sqlCommand.ExecuteNonQuery();
        }
        public void DeleteById(Product product) 
        {
            using var sqlConnection = GetConnection(connection);
            sqlConnection.Open();
            string query = "UPDATE Products SET Name=@Name,Price=@Price WHERE Id=@Id";
            SqlCommand sqlCommand = new SqlCommand(@query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Id", product.Id);
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
