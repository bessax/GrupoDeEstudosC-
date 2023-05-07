using System.Reflection;

namespace ByteBank.Infrastructure.Data;

public class ByteBankContext : DbContext
{
    public ByteBankContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Agencia> Agencias => Set<Agencia>();
    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Conta> Contas => Set<Conta>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly());
    }
}