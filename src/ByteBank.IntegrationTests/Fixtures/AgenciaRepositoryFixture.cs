namespace ByteBank.IntegrationTests.Fixtures;

public class AgenciaRepositoryFixture : IDisposable
{
    private bool _disposedValue;

    public AgenciaRepositoryFixture(DbContextFixture fixture)
    {
        var options = fixture.Options;
        Context = new ByteBankContext(options);

        Repository = new AgenciaRepository(
            Context,
            new Mock<IUnitOfWork>().Object);

        Seed();
    }

    public ByteBankContext Context { get; }
    public AgenciaRepository Repository { get; }

    private void Seed()
    {
        Context.Agencias.AddRange(
            new Agencia(
                "Agencia 1",
                new Endereco(
                    "Rua 1",
                    "12345678",
                    123,
                    "Casa 1")));

        Context.SaveChanges();
    }

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
                Context.Dispose();
            }

            _disposedValue = true;
        }
    }
}