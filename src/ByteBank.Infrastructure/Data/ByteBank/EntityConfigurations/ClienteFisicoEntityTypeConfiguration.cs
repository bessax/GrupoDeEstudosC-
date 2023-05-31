namespace ByteBank.Infrastructure.Data.ByteBank.EntityConfigurations;

public class ClienteFisicoEntityTypeConfiguration
    : IEntityTypeConfiguration<ClienteFisico>
{
    public void Configure(EntityTypeBuilder<ClienteFisico> builder)
    {
        builder.Property(cf => cf.Cpf);
    }
}