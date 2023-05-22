namespace ByteBank.Infrastructure.Data.Identity;

public class IdentityContext
    : IdentityDbContext<IdentityUser>
{
    public IdentityContext(DbContextOptions<IdentityContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}