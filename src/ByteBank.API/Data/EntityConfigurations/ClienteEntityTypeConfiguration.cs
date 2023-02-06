// <copyright file="ClienteEntityTypeConfiguration.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ByteBank.API.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByteBank.API.Data.EntityConfigurations
{
    public class ClienteEntityTypeConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder
                .ToTable("Cliente");

            builder
                .HasOne(c => c.Endereco)
                .WithOne()
                .HasForeignKey<EnderecoCliente>("ClienteId")
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(c => c.Contas)
                .WithOne()
                .HasForeignKey("ClienteId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}