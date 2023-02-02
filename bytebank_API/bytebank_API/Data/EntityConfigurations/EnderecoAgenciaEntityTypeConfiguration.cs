using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using bytebank_API.Models;

namespace bytebank_API.Data.EntityConfigurations
{
    public class EnderecoAgenciaEntityTypeConfiguration : IEntityTypeConfiguration<EnderecoAgencia>
    {
        public void Configure(EntityTypeBuilder<EnderecoAgencia> builder)
        {
            builder
                .ToTable("EnderecoAgencia");
        }
    }
}
