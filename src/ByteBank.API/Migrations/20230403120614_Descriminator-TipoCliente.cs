using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByteBank.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class DescriminatorTipoCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cnpj",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoCliente",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cnpj",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "TipoCliente",
                table: "Cliente");
        }
    }
}
