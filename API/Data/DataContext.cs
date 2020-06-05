using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, 
        IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(userRole1 => new {userRole1.UserId, userRole1.RoleId});

                userRole.HasOne(userRole1 => userRole1.Role)
                    .WithMany(role => role.UserRoles)
                    .HasForeignKey(userRole1 => userRole1.RoleId)
                    .IsRequired();
                
                userRole.HasOne(userRole1 => userRole1.User)
                    .WithMany(role => role.UserRoles)
                    .HasForeignKey(userRole1 => userRole1.UserId)
                    .IsRequired();

            });
        }
    }
}