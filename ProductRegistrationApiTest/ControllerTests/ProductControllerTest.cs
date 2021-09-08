using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using ProductRegistrationApi.Controllers;
using ProductRegistrationApi.Models;
using Xunit;

namespace ProductRegistrationApiTest.ControllerTests
{
  public class ProductControllerTest
  {
    private ProductController _productController;
    private ProductService _productService;
    private ProductContext _context;
    private Mock<IProductManager> _mock;

    public ProductControllerTest()
    {
      var options = new DbContextOptionsBuilder<ProductContext>()
                .UseInMemoryDatabase(databaseName: "productServiceDBTest")
                .Options;
      _context = new ProductContext(options);
      _mock = new Mock<IProductManager>();
      _productService = new ProductService(_context, _mock.Object);
      _productController = new ProductController(_context, _productService);
    }

    [Fact]
    public void GetProductItemsTest()
    {
      var result = _productController.GetProductItems().Result as OkObjectResult;
      Assert.IsType<OkObjectResult>(result); // verifica se retorna o statuscode 200ok
    }

    [Fact]
    public void PostProductTest()
    {
      _mock.Setup(x => x.GetSalePrice(It.IsAny<string>(), It.IsAny<float>())).Returns(125);
      Product product = new Product { Description = "Descrição brinquedo 1", CostPrice = 100, Category = "Brinquedos" };
      var result = _productController.PostProduct(product).Result as OkObjectResult;
      Assert.IsType<OkObjectResult>(result);
    }
  }
}