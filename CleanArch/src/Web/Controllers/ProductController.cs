using Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductServices _productservices;
        public ProductController(IProductServices productServices)
        {
            _productservices = productServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productservices.GetProducts());
        }
    }
}
