using System.Data.SqlClient;
using WebApptoConnectDatabase.Model;
namespace WebApptoConnectDatabase.Services
{

    public class ProductService
    {
        public static string db_source = "";
        public static string db_database = "";
        public static string db_userId = ""; 
        public static string db_password = "";
        public ProductService() { }

        public SqlConnection GetDatabaseconnection()
        {
            SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder();
            conn.UserID = db_userId;
            conn.Password = db_password;
            conn.InitialCatalog = db_database;
            conn.DataSource = db_source;

            return new SqlConnection(conn.ConnectionString);
        }

        public List<Product> GetProducts()
        {
            SqlConnection sqlConnection = GetDatabaseconnection();
            List<Product> products = new List<Product>();
            string sqlstatement = "Select * from the Products";
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(sqlstatement, sqlConnection);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        ProductId = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        ProductQuantity = reader.GetInt32(2)
                    };
                    products.Add(product);
                }
            }
            sqlConnection.Close();
            return products;
        }

    }
}
