using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApptoConnectDatabase.Model;
using WebApptoConnectDatabase.Services;

namespace WebApptoConnectDatabase.Pages
{
    public class IndexModel : PageModel
    {

        public List<Product> Products;

        public void OnGet()
        {
            ProductService productService = new ProductService();
            Products  = productService.GetProducts();
        }
    }
}
