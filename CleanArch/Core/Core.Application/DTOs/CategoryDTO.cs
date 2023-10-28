using System.ComponentModel.DataAnnotations;

namespace Core.Application;

public class CategoryDTO
{
    public int IdCategory { get; set; }
    
    [Required(ErrorMessage = "Informe o Nome!")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }
}
