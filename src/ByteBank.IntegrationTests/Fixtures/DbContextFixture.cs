namespace ByteBank.IntegrationTests.Fixtures;

public class DbContextFixture : IDisposable
{
    private bool _disposedValue;

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
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                using var context = new ByteBankContext(Options);
                context.Database.EnsureDeleted();
            }

            _disposedValue = true;
        }
    }
}