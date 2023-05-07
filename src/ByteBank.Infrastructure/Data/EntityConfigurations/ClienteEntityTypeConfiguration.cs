namespace ByteBank.Infrastructure.Data.EntityConfigurations;

public class ClienteEntityTypeConfiguration
    : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Nome);

        builder.OwnsOne(
            c => c.Endereco,
            x =>
            {
                x.Property(e => e.Logradouro);
                x.Property(e => e.Complemento);
                x.Property(e => e.Cep);
                x.Property(e => e.Numero);
            });

        builder.Property<int>("TipoClienteId");

        builder.HasOne<TipoCliente>()
            .WithMany()
            .HasForeignKey("TipoClienteId")
            .IsRequired();

        builder.HasDiscriminator<int>("TipoClienteId")
            .HasValue<ClienteFisico>(TipoCliente.Fisico.Id)
            .HasValue<ClienteJuridico>(TipoCliente.Juridico.Id);
    }
}