using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ByteBank.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco_Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco_Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco_Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco_Numero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoCliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoConta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoConta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco_Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco_Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco_Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco_Numero = table.Column<int>(type: "int", nullable: false),
                    TipoClienteId = table.Column<int>(type: "int", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_TipoCliente_TipoClienteId",
                        column: x => x.TipoClienteId,
                        principalTable: "TipoCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Saldo = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    AgenciaId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    TipoContaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contas_Agencias_AgenciaId",
                        column: x => x.AgenciaId,
                        principalTable: "Agencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contas_TipoConta_TipoContaId",
                        column: x => x.TipoContaId,
                        principalTable: "TipoConta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoCliente",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fisico" },
                    { 2, "Juridico" }
                });

            migrationBuilder.InsertData(
                table: "TipoConta",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Corrente" },
                    { 2, "Poupanca" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_TipoClienteId",
                table: "Clientes",
                column: "TipoClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_AgenciaId",
                table: "Contas",
                column: "AgenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_ClienteId",
                table: "Contas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_TipoContaId",
                table: "Contas",
                column: "TipoContaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "Agencias");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "TipoConta");

            migrationBuilder.DropTable(
                name: "TipoCliente");
        }
    }
}
