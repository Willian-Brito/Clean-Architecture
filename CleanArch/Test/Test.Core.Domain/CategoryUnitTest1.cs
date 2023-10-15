using Core.Domain;
using FluentAssertions;

namespace Test.Core.Domain;

public class CategoryUnitTest1
{
    [Fact(DisplayName = "Não deve criar categoria quando o idCategory for negativo")]
    public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Category(-1, "Category Name");

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("IdCategory inválido!");
    }

    [Fact(DisplayName = "Criar categoria com o estado válido")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "Category Name");
        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Não deve criar categoria quando o nome for menor que 3 caracteres")]
    public void CreateCategory_ShortNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Category(1, "Ca");

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Nome inválido, é necessário ter no minimo 3 caracteres!");
    }

    [Fact(DisplayName = "Não deve criar categoria quando o nome for vazio")]
    public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Category(1, "");

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Informe o nome!");
    }

    [Fact(DisplayName = "Não deve criar categoria quando o nome for nulo")]
    public void CreateCategory_WithNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new Category(1, null);

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Informe o nome!");
    }
}