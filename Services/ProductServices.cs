using System.Data.SqlClient;
using WebApptoConnectDatabase.Model;
namespace WebApptoConnectDatabase.Services
{

    public class ProductService : IProductService
    {
        //public static string db_source = "carcollection.database.windows.net";
        //public static string db_database = "Products";
        //public static string db_userId = "sqldbuser"; 
        //public static string db_password = "AzureUser@2024";
        IConfiguration configuration;
        public ProductService(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public SqlConnection GetDatabaseconnection()
        {
            SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder();
            //conn.UserID = db_userId;
            //conn.Password = db_password;
            //conn.InitialCatalog = db_database;
            //conn.DataSource = db_source;
            conn.ConnectionString = configuration.GetConnectionString("SqlConnectionstring");

            return new SqlConnection(conn.ConnectionString);
        }

        public List<Product> GetProducts()
        {
            SqlConnection sqlConnection = GetDatabaseconnection();
            List<Product> products = new List<Product>();
            string sqlstatement = "Select ProductId, ProductName, Quantity from Products";
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
