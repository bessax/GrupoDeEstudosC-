namespace ByteBank.IntegrationTests.Fixtures;

public class DbContextFixture : IDisposable
{
    public DbContextFixture()
    {
        Options = new DbContextOptionsBuilder<ByteBankContext>()
            .UseSqlite("Data Source=ByteBank.db")
            .Options;

        using var context = new ByteBankContext(Options);

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }

    public DbContextOptions<ByteBankContext> Options { get; }

    public void Dispose()
    {
        using var context = new ByteBankContext(Options);

        context.Database.EnsureDeleted();
    }
}