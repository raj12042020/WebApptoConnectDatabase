using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApptoConnectDatabase.Model;
using WebApptoConnectDatabase.Services;

namespace WebApptoConnectDatabase.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductService productService;

        public List<Product> Products;

        public IndexModel(IProductService _productService)
        {
            productService = _productService;
        }

        public void OnGet()
        {
            Products  = productService.GetProducts();
        }
    }
}
