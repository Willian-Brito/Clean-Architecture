using System.ComponentModel.DataAnnotations;

namespace Core.Application.DTOs.Categories;
public class CategoryCreateDTO
{
    [Required(ErrorMessage = "Informe o Nome!")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }
}
