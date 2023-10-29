using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products (Name, Description, Price, Stock, Image, IdCategory, CreatedDate) " +
                                    $"VALUES ('Caderno espiral', 'Caderno espiral 100 folhas', 7.45,50, 'caderno.jpg', 1, '{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")}')");

            migrationBuilder.Sql("INSERT INTO Products (Name, Description, Price, Stock, Image, IdCategory, CreatedDate) " +
                                    $"VALUES ('Estojo escolar', 'Estojo escolar cinza', 5.65,70, 'estojo.jpg', 1, '{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")}')");

            migrationBuilder.Sql("INSERT INTO Products (Name, Description, Price, Stock, Image, IdCategory, CreatedDate) " +
                                    $"VALUES ('Borracha escolar', 'Borracha branca', 3.25,80, 'borracha.jpg', 1, '{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")}')");

            migrationBuilder.Sql("INSERT INTO Products (Name, Description, Price, Stock, Image, IdCategory, CreatedDate) " +
                                    $"VALUES ('Calculadora escolar', 'Calculadora simples', 15.39,20, 'calculadora.jpg', 2, '{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")}')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE Products");
        }
    }
}
