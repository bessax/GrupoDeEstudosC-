namespace ByteBank.Infrastructure.Data.ByteBank.EntityConfigurations;

public class TipoClienteEntityTypeConfiguration
    : IEntityTypeConfiguration<TipoCliente>
{
    public void Configure(EntityTypeBuilder<TipoCliente> builder)
    {
        builder.HasKey(tc => tc.Id);

        builder.Property(tc => tc.Id)
            .ValueGeneratedOnAdd();

        builder.Property(tc => tc.Name);

        builder.HasData(
            TipoCliente.Fisico,
            TipoCliente.Juridico);
    }
}