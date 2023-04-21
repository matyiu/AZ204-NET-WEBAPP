using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webapp.Models;
using webapp.Services;

namespace AZ_204_WindowsWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productsService;

        public IndexModel(IProductService productService)
        {
            _productsService = productService;
        }

        public List<Product> Products = new List<Product>();
        public void OnGet()
        {
            Products = _productsService.GetAll();
        }
    }
}
