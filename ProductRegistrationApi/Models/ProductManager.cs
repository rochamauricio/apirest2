using System.IO;
using System.Net;

namespace ProductRegistrationApi.Models
{
  public class ProductManager : IProductManager
  {
    public float GetSalePrice(string category, float cost)
    {
      string url = "http://localhost:5000/api1/price?category=" + category + "&cost=" + cost;
      var request = WebRequest.CreateHttp(url);
      request.Method = "GET";
      request.UserAgent = "myRequest";
      float salePrice = 0f;

      using (var response = request.GetResponse())
      {
        var dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        salePrice = float.Parse(reader.ReadToEnd().ToString());
        dataStream.Close();
        response.Close();
      }
      return salePrice;
    }
  }
}