using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByteBank.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class Alteracaodedatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AtualizadoEm",
                table: "EnderecoCliente",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CriadoEm",
                table: "EnderecoCliente",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExcluidoEm",
                table: "EnderecoCliente",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AtualizadoEm",
                table: "EnderecoAgencia",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CriadoEm",
                table: "EnderecoAgencia",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExcluidoEm",
                table: "EnderecoAgencia",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AtualizadoEm",
                table: "Cliente",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CriadoEm",
                table: "Cliente",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExcluidoEm",
                table: "Cliente",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AtualizadoEm",
                table: "Agencia",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CriadoEm",
                table: "Agencia",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExcluidoEm",
                table: "Agencia",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AtualizadoEm",
                table: "EnderecoCliente");

            migrationBuilder.DropColumn(
                name: "CriadoEm",
                table: "EnderecoCliente");

            migrationBuilder.DropColumn(
                name: "ExcluidoEm",
                table: "EnderecoCliente");

            migrationBuilder.DropColumn(
                name: "AtualizadoEm",
                table: "EnderecoAgencia");

            migrationBuilder.DropColumn(
                name: "CriadoEm",
                table: "EnderecoAgencia");

            migrationBuilder.DropColumn(
                name: "ExcluidoEm",
                table: "EnderecoAgencia");

            migrationBuilder.DropColumn(
                name: "AtualizadoEm",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "CriadoEm",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "ExcluidoEm",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "AtualizadoEm",
                table: "Agencia");

            migrationBuilder.DropColumn(
                name: "CriadoEm",
                table: "Agencia");

            migrationBuilder.DropColumn(
                name: "ExcluidoEm",
                table: "Agencia");
        }
    }
}
