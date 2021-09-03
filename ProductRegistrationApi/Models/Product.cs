using System;
using System.ComponentModel.DataAnnotations;

namespace ProductRegistrationApi.Models
{
  public class Product
  {
    public long Id { get; set; }

    [Required(ErrorMessage = "O preenchimento da categoria é obrigatório")]
    public string Category { get; set; }

    [Required(ErrorMessage = "O preenchimento da descrição é obrigatório")]
    [MaxLength(50, ErrorMessage = "O tamanho máximo da descrição é de 50 caracteres")]
    public string Description { get; set; }

    [Required(ErrorMessage = "O preenchimento do preço de custo é obrigatório")]
    [Range(0.1f, float.MaxValue, ErrorMessage = "O preenchimento do preço de custo é obrigatório")]
    public float CostPrice { get; set; }
    public DateTime CreationDate { get; set; }
    public float SalePrice { get; set; }

    public void CheckDescriptionSoftplayer()
    {
      if (Description.Contains("Softplayer") || Description.Contains("softplayer"))
        Category = "Softplan";
    }
  }
}


