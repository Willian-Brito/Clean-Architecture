namespace Core.Domain;

public sealed class Product : EntityBase
{
    #region Propriedades da Classe
    public int IdProduct { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string Image { get; private set; }
    public int IdCategory { get; set; }
    public Category Category { get; set; }
    #endregion
    
    #region Construtor
    public Product(string name, string description, decimal price, int stock, string image)
    {
        ValidateDomain(name, description, price, stock, image);
        SetAtributes(name, description, price, stock, image);
    }

    public Product(int idProduct, string name, string description, decimal price, int stock, string image)
    {
        DomainExceptionValidation.When(idProduct < 0, "IdProduct inválido!");
        
        ValidateDomain(name, description, price, stock, image);
        SetAtributes(name, description, price, stock, image);

        IdProduct = idProduct;
    }
    #endregion

    #region Metodos

    #region Update
    public void Update(int idProduct, string name, string description, decimal price, int stock, string image, int idCategory)
    {
        DomainExceptionValidation.When(idProduct < 0, "IdProduct inválido!");
        DomainExceptionValidation.When(idCategory < 0, "IdCategory inválido!");

        ValidateDomain(name, description, price, stock, image);
        SetAtributes(name, description, price, stock, image);

        IdProduct = idProduct;
        IdCategory = idCategory;
    }
    #endregion

    #region ValidateDomain
    private void ValidateDomain(string name, string description, decimal price, int stock, string image)
    {
        #region Name
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "Informe o nome!");
        DomainExceptionValidation.When(name.Length < 3, "Nome inválido, é necessário ter no minimo 3 caracteres!");
        #endregion

        #region Description
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(description), "Informe a Descrição!");
        DomainExceptionValidation.When(description.Length < 5, "Descrição inválida, é necessário ter no minimo 5 caracteres!");
        #endregion

        #region Price
        DomainExceptionValidation.When(price < 0, "Preço Inválido!");
        #endregion

        #region Stock
        DomainExceptionValidation.When(stock < 0, "Estoque Inválido!");
        #endregion

        #region Image
        DomainExceptionValidation.When(image?.Length > 250, "Imagem inválida, é necessário ter no máximo 250 caracteres!");
        #endregion
    }
    #endregion

    #region SetAtributes
    private void SetAtributes(string name, string description, decimal price, int stock, string image)
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
    }
    #endregion
    
    #endregion
}
