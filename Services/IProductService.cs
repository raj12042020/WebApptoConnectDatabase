using System.Data.SqlClient;
using WebApptoConnectDatabase.Model;

namespace WebApptoConnectDatabase.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}