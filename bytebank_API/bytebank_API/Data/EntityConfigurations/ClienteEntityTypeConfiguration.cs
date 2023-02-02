using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using bytebank_API.Models;

namespace bytebank_API.Data.EntityConfigurations
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
