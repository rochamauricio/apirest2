using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductRegistrationApi.Models
{
  public class ProductService
  {
    private ProductContext _context;
    private IProductManager _productManager;
    public ProductService(ProductContext context, IProductManager productManager)
    {
      _context = context;
      _productManager = productManager;
    }
    public void AddProduct(Product product)
    {
      product.CheckDescriptionSoftplayer();
      product.CreationDate = DateTime.Today;
      product.SalePrice = _productManager.GetSalePrice(product.Category, product.CostPrice);
      _context.Add(product);
      _context.SaveChanges();
    }
    public List<Product> ListProducts()
    {
      return _context.Products.OrderBy(o => o.Description).ToList(); // retorna lista ordenada pela descricao
    }
  }
}


