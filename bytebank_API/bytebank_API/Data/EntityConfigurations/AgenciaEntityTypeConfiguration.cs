using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using bytebank_API.Models;

namespace bytebank_API.Data.EntityConfigurations
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
