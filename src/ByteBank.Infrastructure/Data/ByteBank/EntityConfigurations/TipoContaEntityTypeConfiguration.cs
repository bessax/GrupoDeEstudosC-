namespace ByteBank.Infrastructure.Data.ByteBank.EntityConfigurations;

public class TipoContaEntityTypeConfiguration
    : IEntityTypeConfiguration<TipoConta>
{
    public void Configure(EntityTypeBuilder<TipoConta> builder)
    {
        builder.HasKey(tc => tc.Id);

        builder.Property(tc => tc.Id)
            .ValueGeneratedOnAdd();

        builder.Property(tc => tc.Name);

        builder.HasData(
            TipoConta.Corrente,
            TipoConta.Poupanca);
    }
}