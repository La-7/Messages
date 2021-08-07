using MessagesCRUD.Application.Interfaces;
using MessagesCRUD.Domain;
using MessagesCRUD.Persistence.EntityTypeConfiguration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MessagesCRUD.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>, IApplicationDbContext
    {
        public DbSet<Message> Messages { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MessageConfiguration());
            base.OnModelCreating(builder);

            builder.Entity<AppUser>(entity => entity.ToTable(name: "Users"));
            builder.Entity<IdentityRole>(entity => entity.ToTable(name: "Roles"));
            builder.Entity<IdentityUserRole<string>>(entity =>
                entity.ToTable(name: "UserRoles"));
            builder.Entity<IdentityUserClaim<string>>(entity =>
                entity.ToTable(name: "UserClaim"));
            builder.Entity<IdentityUserLogin<string>>(entity =>
                entity.ToTable("UserLogins"));
            builder.Entity<IdentityUserToken<string>>(entity =>
                entity.ToTable("UserTokens"));
            builder.Entity<IdentityRoleClaim<string>>(entity =>
                entity.ToTable("RoleClaims"));

            builder.ApplyConfiguration(new AppUserConfiguration());
        }
    }
}
