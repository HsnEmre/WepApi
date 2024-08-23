using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        /*
         bir ifade readonly olarak tanımlandıysa ya ctorda değer atanabilit yada tanımlandığı yerde         
         */
        #region Dependency Injection
        //prop kullanıldığı anda logger ın concrete ifadesi elimde olucak
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }
        #endregion

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = new List<Product>()
            {
                new Product{ Id = 1,ProductName="Comuputer"},
                new Product{ Id = 2,ProductName="Keyboard"},
                new Product{ Id = 3,ProductName="Maouse"},
                new Product{ Id = 4,ProductName="Processor"},
            };
            _logger.LogInformation("GetAllProducts action has been called.");
            return Ok(products);
        }

        [HttpPost]
        public IActionResult GetAllProducts([FromBody] Product product)
        {
            _logger.LogWarning("Product has been created.");
            return StatusCode(201);//created

        }
    }
}
