using System.Reflection;
using Darwin.Data.EntityConfigurations;
using Darwin.Entities;
using Darwin.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Darwin.Data;

public class AppDbContext : IdentityDbContext<
    AppUser,
    AppRole,
    Guid,
    IdentityUserClaim<Guid>,
    AppUserRole,
    IdentityUserLogin<Guid>,
    IdentityRoleClaim<Guid>,
    IdentityUserToken<Guid>
    >
{
    public const string DEFAULT_SCHEMA = "dbo";
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    private readonly ICurrentUserService _currentUserService;
    private IDateTimeService _dateTimeService;

    public AppDbContext(
        DbContextOptions<AppDbContext> options,
        ICurrentUserService currentUserService,
        IDateTimeService dateTimeService)
        : base(options)
    {
        this._currentUserService = currentUserService;
        this._dateTimeService = dateTimeService;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema(DEFAULT_SCHEMA);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<IEntity<Guid>>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatorId = _currentUserService.UserId;
                    entry.Entity.CreatedOn = _dateTimeService.Now;
                    break;

                case EntityState.Modified:
                    entry.Entity.UpdaterId = _currentUserService.UserId;
                    entry.Entity.UpdatedOn = _dateTimeService.Now;
                    break;
            }
        }

        var result = await base.SaveChangesAsync(cancellationToken);
        return result;
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }
}