using ByteBank.API.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByteBank.API.Data.EntityConfigurations
{
    public class EnderecoClienteEntityTypeConfiguration : IEntityTypeConfiguration<EnderecoCliente>
    {
        public void Configure(EntityTypeBuilder<EnderecoCliente> builder)
        {
            builder
                .ToTable("EnderecoCliente");
        }
    }
}