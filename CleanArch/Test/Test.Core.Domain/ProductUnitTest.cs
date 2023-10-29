using Core.Domain.Entities;
using Core.Domain.Validations;
using FluentAssertions;

namespace Test.Core.Domain;

public class ProductUnitTest
{
    #region IdProduct
    [Fact(DisplayName = "Não deve criar produto quando o idProduct for negativo")]
    public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Product(-1, "Product Name", "Product Description", 9.99M, 99, "Product Image");

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("IdProduct inválido!");
    }
    #endregion

    #region Product

    [Fact(DisplayName = "Criar produto com o estado válido")]
    public void CreateProduct_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.99M, 99, "Product Image");
        action.Should().NotThrow<DomainExceptionValidation>();
    }
    #endregion

    #region Name

    [Fact(DisplayName = "Não deve criar produto quando o nome for menor que 3 caracteres")]
    public void CreateProduct_ShortNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Product(1, "Pr", "Product Description", 9.99M, 99, "Product Image");

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Nome inválido, é necessário ter no minimo 3 caracteres!");
    }

    [Fact(DisplayName = "Não deve criar produto quando o nome for vazio")]
    public void CreateProduct_MissingNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Product(1, "", "Product Description", 9.99M, 99, "Product Image");

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Informe o nome!");
    }

    [Fact(DisplayName = "Não deve criar produto quando o descrição for nulo")]
    public void CreateCategory_WithNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new Product(1, null, "Product Description", 9.99M, 99, "Product Image");

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Informe o nome!");
    }
    #endregion

    #region Description
    
    [Fact(DisplayName = "Não deve criar produto quando a descrição for menor que 5 caracteres")]
    public void CreateProduct_ShortDescriptionValue_DomainExceptionRequiredName()
    {
        Action action = () => new Product(1, "Product Name", "Prod", 9.99M, 99, "Product Image");

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Descrição inválida, é necessário ter no minimo 5 caracteres!");
    }

    [Fact(DisplayName = "Não deve criar produto quando a descrição for vazia")]
    public void CreateProduct_MissingDescriptionValue_DomainExceptionRequiredName()
    {
        Action action = () => new Product(1, "Product Name", "", 9.99M, 99, "Product Image");

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Informe a Descrição!");
    }

    [Fact(DisplayName = "Não deve criar produto quando o descrição for nulo")]
    public void CreateCategory_WithDescriptionValue_DomainExceptionInvalidName()
    {
        Action action = () => new Product(1, "Product Name", null, 9.99M, 99, "Product Image");

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Informe a Descrição!");
    }
    #endregion

    #region Price

    [Theory(DisplayName = "Não deve criar produto quando o preço for negativo")]
    [InlineData(-5)]
    public void CreateProduct_InvalidPriceValue_ExceptionDomainNegativeValue(int value)
    {
        Action action = () => new Product(1, "Product Name", "Product Description", value, 99, "Product Image");

        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Preço Inválido!");
            
    }
    #endregion

    #region Stock

    [Theory(DisplayName = "Não deve criar produto quando o estoque for negativo")]
    [InlineData(-5)]
    public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.99M, value, "Product Image");

        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Estoque Inválido!");
            
    }
    #endregion

    #region Image
    [Fact(DisplayName = "Não deve criar produto quando a imagem for maior que 250 caracteres")]
    public void CreateProduct_LongImageName_DomainExceptionImageName()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.99M, 99, "Product Image toooooooooooooooooooooooooooooooooooooooooooooooooooooooooo lonnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg");

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Imagem inválida, é necessário ter no máximo 250 caracteres!");
    }

    [Fact(DisplayName = "Deve criar produto quando a imagem for nulo")]
    public void CreateProduct_WithNullImageName_NoDomainExceptionImage()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.99M, 99, null);

        action.Should().NotThrow<DomainExceptionValidation>();
            
    }

    [Fact(DisplayName = "Deve criar produto quando a imagem for nulo sem lançar a excessão NullReferenceException")]
    public void CreateProduct_WithNullImageName_NoNullReferenceException()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.99M, 99, null);

        action.Should().NotThrow<NullReferenceException>();
            
    }

    [Fact(DisplayName = "Deve criar produto quando a imagem for vazia")]
    public void CreateProduct_WithEmptymageName_NoDomainExceptionImage()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.99M, 99, "");

        action.Should().NotThrow<DomainExceptionValidation>();
            
    }
    #endregion
}
