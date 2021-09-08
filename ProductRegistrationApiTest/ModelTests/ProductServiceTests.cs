using Microsoft.EntityFrameworkCore;
using Moq;
using ProductRegistrationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ProductRegistrationApiTest.ModelTests
{
  public class ProductServiceTests
  {
    private ProductService _productService;
    private ProductContext _context;
    private Mock<IProductManager> _mock;

    public ProductServiceTests()
    {
      var options = new DbContextOptionsBuilder<ProductContext>()
          .UseInMemoryDatabase(databaseName: "productServiceDBTest")
          .Options;
      _context = new ProductContext(options);
      _mock = new Mock<IProductManager>();
      _productService = new ProductService(_context, _mock.Object);
    }

    [Fact]
    public void AddProductAndListProductsTest()
    {
      List<Product> expected = new List<Product>();
      List<Product> actual = new List<Product>();

      // CASO 1
      // valores esperados
      expected.Add(
        new Product
        {
          Id = 1,
          Category = "Brinquedos",
          Description = "Descrição 1",
          CreationDate = DateTime.Today,
          CostPrice = 100f,
          SalePrice = 125f
        });

      // valores obtidos
      _mock.Setup(x => x.GetSalePrice(It.IsAny<string>(), It.IsAny<float>())).Returns(125);
      _productService.AddProduct(
       new Product
       {
         Id = 1,
         Category = "Brinquedos",
         Description = "Descrição 1",
         CostPrice = 100f
       });

      // CASO 2
      // valores esperados
      expected.Add(
        new Product
        {
          Id = 2,
          Category = "Bebidas",
          Description = "Descrição 2",
          CreationDate = DateTime.Today,
          CostPrice = 100f,
          SalePrice = 130f
        });

      // valores obtidos
      _mock.Setup(x => x.GetSalePrice(It.IsAny<string>(), It.IsAny<float>())).Returns(130);
      _productService.AddProduct(
       new Product
       {
         Id = 2,
         Category = "Bebidas",
         Description = "Descrição 2",
         CostPrice = 100f
       });

      // CASO 3
      // valores esperados
      expected.Add(
        new Product
        {
          Id = 3,
          Category = "Softplan",
          Description = "Descrição 3 softplayer",
          CreationDate = DateTime.Today,
          CostPrice = 100f,
          SalePrice = 105f
        });

      // valores obtidos
      _mock.Setup(x => x.GetSalePrice(It.IsAny<string>(), It.IsAny<float>())).Returns(105);
      _productService.AddProduct(
       new Product
       {
         Id = 3,
         Category = "Blabla",
         Description = "Descrição 3 softplayer",
         CostPrice = 100f
       });

      actual = _productService.ListProducts().ToList();

      for (int i = 0; i < actual.Count; i++)
      {
        Assert.Equal(expected[i].Id, actual[i].Id);
        Assert.Equal(expected[i].Category, actual[i].Category);
        Assert.Equal(expected[i].Description, actual[i].Description);
        Assert.Equal(expected[i].CostPrice, actual[i].CostPrice);
        Assert.Equal(expected[i].CostPrice, actual[i].CostPrice);
        Assert.Equal(expected[i].CreationDate, actual[i].CreationDate);
        Assert.Equal(expected[i].SalePrice, actual[i].SalePrice);
      }
    }
  }
}
