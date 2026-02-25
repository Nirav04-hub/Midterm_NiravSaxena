using Microsoft.AspNetCore.Mvc;
using MidtermAPI_NiravSaxena.Models;

namespace MidtermAPI_NiravSaxena.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NSProductController : Controller
    {

        private readonly ILogger<NSProductController> _logger;

        public NSProductController(ILogger<NSProductController> logger)
        {
            _logger = logger;
        }

        //Data
        private List<NSProduct> _products = new List<NSProduct>
        {
            new NSProduct { Id = 1, Name = "Laptop", Quantity= 1},
            new NSProduct { Id = 2, Name = "Smartphone", Quantity = 1},
            new NSProduct { Id = 3, Name = "Headphones",    Quantity=1}
        };

        public Dictionary<string, int> RequestCounts = new();


        [HttpGet("/Products")]
        public IActionResult GetProducts()
        {

            return (Ok(new
            {
                message = "Products retrieved successfully",
                Products = _products
            }));
        }

        [HttpPost("/Product")]
        public IActionResult CreateProduct([FromBody] NSProduct product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = "InvalidProduct",
                    message = "Name cannot be empty"
                });
            }

            _products.Add(product);

            return StatusCode(201, new
            {
                message = "Product created",
                Product = product
            });
        }

        [HttpGet("/usage")]
        public IActionResult GetUsage()
        {
            var apiKey = Request.Headers["X-Api-Key"].ToString();

            if (!RequestCounts.ContainsKey(apiKey))
                RequestCounts[apiKey] = 0;

            RequestCounts[apiKey]++;

            return Ok(new
            {
                apiKey = apiKey,
                count = RequestCounts[apiKey]
            });
        }
    }
}
