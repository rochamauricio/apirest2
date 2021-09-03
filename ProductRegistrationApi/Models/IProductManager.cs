namespace ProductRegistrationApi.Models
{
  public interface IProductManager
  {
    float GetSalePrice(string category, float cost);
  }
}