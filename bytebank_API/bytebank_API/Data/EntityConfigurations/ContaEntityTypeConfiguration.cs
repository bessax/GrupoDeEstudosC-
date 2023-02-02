using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using bytebank_API.Models;

namespace bytebank_API.Data.EntityConfigurations
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
