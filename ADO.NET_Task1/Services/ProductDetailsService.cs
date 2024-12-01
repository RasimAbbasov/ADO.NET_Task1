using ADO.NET_Task1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task1.Services
{
    internal class ProductDetailsService
    {
        const string connection = "Server=DESKTOP-Q262GML\\SQLEXPRESS01;Database=ProductManagementDB;Trusted_Connection=True;";
        public void Create(ProductDetails productDetails)
        {
            using var sqlConnection = GetConnection(connection);
            sqlConnection.Open();
            string query = "INSERT INTO ProductDetails VALUES(@Quantity,@ProductLink,@ProductId)";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Quantity", productDetails.Quantity);
            sqlCommand.Parameters.AddWithValue("@ProductLink", productDetails.ProductLink);
            sqlCommand.Parameters.AddWithValue("@ProductId", productDetails.ProductId);
            sqlCommand.ExecuteNonQuery();
        }
        public List<ProductDetails> ReadAll()
        {
            List<ProductDetails> productDetails = new List<ProductDetails>();
            using var sqlConnection = GetConnection(connection);
            sqlConnection.Open();
            string query = "SELECT * FROM ProductDetails";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    int id = (int)reader.GetValue(0);
                    string quantity = (string)reader.GetValue(1);
                    string productLink = (string)reader.GetValue(2);
                    productDetails.Add(new() { Id = id, Quantity = quantity, ProductLink = productLink });
                }
                return productDetails;
            }
            else
                Console.WriteLine("Table has no rows");
            return productDetails;
        }
        public void UpdateById(int id, ProductDetails productDetails)
        {
            using var sqlConnection = GetConnection(connection);
            sqlConnection.Open();
            string query = "UPDATE ProductDetails SET Quantity=@Quantity,ProductLink=@ProductLink WHERE Id=@Id";
            SqlCommand sqlCommand = new SqlCommand(@query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Id", id);
            sqlCommand.Parameters.AddWithValue("@Quantity", productDetails.Quantity);
            sqlCommand.Parameters.AddWithValue("@ProductLink", productDetails.ProductLink);
            if (sqlCommand.ExecuteNonQuery() > 0)
                Console.WriteLine("Updated");
            else
                Console.WriteLine("Invalid progress");
        }
        public void DeleteById(int id)
        {
            using var sqlConnection = GetConnection(connection);
            sqlConnection.Open();
            string query = "DELETE FROM ProductDetails WHERE Id=@Id";
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
