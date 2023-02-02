using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using bytebank_API.Models;

namespace bytebank_API.Data.EntityConfigurations
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
