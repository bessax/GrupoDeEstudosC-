namespace ByteBank.Infrastructure.Data.EntityConfigurations;

public class ClienteJuridicoEntityTypeConfiguration
    : IEntityTypeConfiguration<ClienteJuridico>
{
    public void Configure(EntityTypeBuilder<ClienteJuridico> builder)
    {
        builder.Property(cj => cj.Cnpj);
    }
}