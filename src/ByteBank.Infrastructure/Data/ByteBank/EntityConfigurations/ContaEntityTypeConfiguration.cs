namespace ByteBank.Infrastructure.Data.ByteBank.EntityConfigurations;

public class ContaEntityTypeConfiguration
    : IEntityTypeConfiguration<Conta>
{
    public void Configure(EntityTypeBuilder<Conta> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Saldo)
            .HasPrecision(10, 2);

        builder.Property(c => c.AgenciaId);

        builder.HasOne<Agencia>()
            .WithMany()
            .HasForeignKey(c => c.AgenciaId)
            .IsRequired();

        builder.HasOne<Cliente>()
            .WithMany()
            .HasForeignKey(c => c.ClienteId)
            .IsRequired();

        builder.Property<int>("TipoContaId");

        builder.HasOne<TipoConta>()
            .WithMany()
            .HasForeignKey("TipoContaId");

        builder.HasDiscriminator<int>("TipoContaId")
            .HasValue<ContaCorrente>(TipoConta.Corrente.Id)
            .HasValue<ContaPoupanca>(TipoConta.Poupanca.Id);
    }
}