namespace ByteBank.Api.Identity;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources
        => Enumerable.Empty<IdentityResource>();

    public static IEnumerable<ApiScope> ApiScopes => new[]
    {
        new ApiScope("bytebank-api", "ByteBank API")
    };

    public static IEnumerable<Client> Clients => new Client[]
    {
        new Client
        {
            ClientId = "bytebank-api-swagger-ui-client",
            ClientName = "ByteBank Swagger UI Client",
            AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
            RequireClientSecret = false,
            AllowedScopes = { "bytebank-api" }
        }
    };
}