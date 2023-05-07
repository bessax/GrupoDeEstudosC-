namespace ByteBank.Infrastructure.Data.EntityConfigurations;

public class ClienteFisicoEntityTypeConfiguration
    : IEntityTypeConfiguration<ClienteFisico>
{
    public void Configure(EntityTypeBuilder<ClienteFisico> builder)
    {
        builder.Property(cf => cf.Cpf);
    }
}