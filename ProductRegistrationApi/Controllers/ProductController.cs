using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProductRegistrationApi.Models;

namespace ProductRegistrationApi.Controllers
{
  [Route("api2")]
  [ApiController]
  public class ProductController : ControllerBase
  {
    private ProductService _productService;

    public ProductController(ProductContext context, ProductService productService)
    {
      _productService = productService;
    }

    // GET: http://localhost:5002/api2
    [HttpGet]
    public ActionResult<List<Product>> GetProductItems()
    {
      return Ok(_productService.ListProducts());
    }

    // Post: http://localhost:5002/api2/insert
    [HttpPost("insert")]
    public ActionResult<string> PostProduct([FromBody] Product product)
    {
      _productService.AddProduct(product);
      if (ModelState.IsValid)
        return Ok("O produto foi salvo com sucesso");
      else return BadRequest(ModelState);
    }
  }
}