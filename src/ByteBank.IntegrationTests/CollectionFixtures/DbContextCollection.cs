namespace ByteBank.IntegrationTests.CollectionFixtures;

[CollectionDefinition(nameof(DbContextCollection))]
public class DbContextCollection : ICollectionFixture<DbContextFixture>
{
}