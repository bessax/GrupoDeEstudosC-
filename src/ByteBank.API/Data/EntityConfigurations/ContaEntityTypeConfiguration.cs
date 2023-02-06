// <copyright file="ContaEntityTypeConfiguration.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ByteBank.API.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByteBank.API.Data.EntityConfigurations
{
    public class ContaEntityTypeConfiguration : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder
                .ToTable("Conta");

            builder
                .HasOne<Agencia>()
                .WithMany()
                .HasForeignKey("AgenciaId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}