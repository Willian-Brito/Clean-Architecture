using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data;

public class ApplicationDbContext : DbContext
{
    #region Propriedades da Classe
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    #endregion

    #region Construtor
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }
    #endregion

    #region Metodos
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
    #endregion
}
