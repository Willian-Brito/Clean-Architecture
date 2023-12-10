using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Core.Domain.Entities;

namespace Core.Application.DTOs.Products;

public class ProductDTO
{
    public int IdProduct { get; set; }

    [Required(ErrorMessage = "Informe o Nome!")]
    [MinLength(3)]
    [MaxLength(100)]
    [DisplayName("Nome")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Informe a Descrição!")]
    [MinLength(5)]
    [MaxLength(200)]
    [DisplayName("Descrição")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Informe o Preço!")]
    [Column(TypeName = "decimal(18,2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [DataType(DataType.Currency)]
    [DisplayName("Preço")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Informe o Estoque!")]
    [Range(1, 9999)]
    [DisplayName("Estoque")]
    public int Stock { get; set; }

    [MaxLength(250)]
    [DisplayName("Imagem")]
    public string? Image { get; set; }
    
    [JsonIgnore]
    public Category? Category { get; set; }

    [DisplayName("Categorias")]
    public int IdCategory { get; set; }
}
