// <copyright file="ByteBankContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ByteBank.API.Models;

using Microsoft.EntityFrameworkCore;

namespace ByteBank.API.Data
{
    public class ByteBankContext : DbContext
    {
        public ByteBankContext(DbContextOptions<ByteBankContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.LogTo(Console.WriteLine); Exemplo de exibição de log no Console.
        }
        public DbSet<Conta> Contas { get; set; } = null!;

        public DbSet<Agencia> Agencias { get; set; } = null!;

        public DbSet<Cliente> Clientes { get; set; } = null!;

        public DbSet<EnderecoAgencia> EnderecosAgencia { get; set; } = null!;

        public DbSet<EnderecoCliente> EnderecosCliente { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ByteBankContext).Assembly);
        }
    }

}