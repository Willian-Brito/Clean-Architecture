using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context;

public class ApplicationDbContext : DbContext
{
    #region Propriedades da Classe
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    #endregion

    #region Construtor
    public ApplicationDbContext(){ }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }
    #endregion

    #region Metodos
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            var connectionString = "Server=localhost; Database=CleanArchDB; User Id=sa; Password=sql@2019; TrustServerCertificate=True;";

            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }        
    }
    #endregion
}
