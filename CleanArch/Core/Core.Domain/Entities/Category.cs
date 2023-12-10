using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Validations;

namespace Core.Domain.Entities;

public sealed class Category : EntityBase
{
    #region Propriedades da Classe

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdCategory { get; private set; }
    public string? Name { get; private set; }
    public ICollection<Product>? Products { get; set; }
    #endregion

    #region Construtor
    public Category(string name)
    {
        ValidateDomain(name);
        Name = name;
    }

    public Category(int idCategory, string name)
    {
        DomainExceptionValidation.When(idCategory < 0, "IdCategory inválido!");
        ValidateDomain(name);

        IdCategory = idCategory;
        Name = name;
    }
    #endregion

    #region Metodos

    public void Update(string name)
    {
        ValidateDomain(name);
        Name = name;
    }

    private void ValidateDomain(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "Informe o nome!");
        DomainExceptionValidation.When(name.Length < 3, "Nome inválido, é necessário ter no minimo 3 caracteres!");
    }
    #endregion
}
