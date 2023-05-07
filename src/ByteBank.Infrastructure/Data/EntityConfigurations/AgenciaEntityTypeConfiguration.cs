namespace ByteBank.Infrastructure.Data.EntityConfigurations;

public class AgenciaEntityTypeConfiguration
    : IEntityTypeConfiguration<Agencia>
{
    public void Configure(EntityTypeBuilder<Agencia> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .ValueGeneratedOnAdd();

        builder.Property(a => a.Nome);

        builder.OwnsOne(
            a => a.Endereco,
            x =>
            {
                x.Property(e => e.Logradouro);
                x.Property(e => e.Complemento);
                x.Property(e => e.Cep);
                x.Property(e => e.Numero);
            });
    }
}