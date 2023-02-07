// <copyright file="AgenciaEntityTypeConfiguration.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ByteBank.API.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByteBank.API.Data.EntityConfigurations
{
    public class AgenciaEntityTypeConfiguration : IEntityTypeConfiguration<Agencia>
    {
        public void Configure(EntityTypeBuilder<Agencia> builder)
        {
            builder
                .ToTable("Agencia");

            builder
                .HasOne(a => a.Endereco)
                .WithOne()
                .HasForeignKey<EnderecoAgencia>("AgenciaId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}