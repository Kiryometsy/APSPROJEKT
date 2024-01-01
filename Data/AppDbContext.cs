using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        //Ustawic baze danych żeby była w środku aplikacji
        private string DbPath { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "Photos.db");
        }

        public DbSet<PhotoEntity> Photos { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();

            var user = new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "user",
                NormalizedUserName = "USER",
                Email = "user@wsei.edu.pl",
                NormalizedEmail = "USER@WSEI.EDU.PL",
                EmailConfirmed = true,
            };

            var admin = new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@wsei.edu.pl",
                NormalizedEmail = "ADMIN@WSEI.EDU.PL",
                EmailConfirmed = true,
            };

            user.PasswordHash = ph.HashPassword(user, "user");
            admin.PasswordHash = ph.HashPassword(admin, "admin");

            modelBuilder.Entity<IdentityUser>()
                .HasData(
                        user,admin
                    );
            var userRole = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "user",
                NormalizedName = "User"
            };
            var adminRole = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "admin",
                NormalizedName = "ADMIN"
            };

            adminRole.ConcurrencyStamp = adminRole.Id;
            userRole.ConcurrencyStamp = userRole.Id;

            modelBuilder.Entity<IdentityRole>()
                .HasData(
                    adminRole, userRole
                );

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = userRole.Id,
                    UserId = user.Id,
                }, new IdentityUserRole<string>()
                {
                    RoleId = adminRole.Id,
                    UserId = admin.Id,
                }
                );

            modelBuilder.Entity<PhotoEntity>()
                .HasOne(c => c.Author)
                .WithMany(o => o.Photos)
                .HasForeignKey(c => c.AuthorId);

            modelBuilder.Entity<AuthorEntity>()
                .HasData(
                    new AuthorEntity()
                    {
                        Id = 1,
                        Name = "Author1",
                        Description = "Pierwszy author"
                    }
                );

            modelBuilder.Entity<PhotoEntity>().HasData(
                new PhotoEntity()
                {
                    PhotoId = 1,
                    Camera = "Nikon",
                    Description = "Zdjęcie wykonane aparatem nikon",
                    Resolution = "126x126",
                    CreatedDate = new DateTime(2024, 1, 1),
                    Format = "Test Format",
                    AuthorId = 1
                },
                new PhotoEntity()
                {
                    PhotoId = 2,
                    Camera = "Sony",
                    Description = "Zdjęcie wykonane aparatem sony",
                    Resolution = "512x512",
                    CreatedDate = new DateTime(2024, 2, 1),
                    Format = "Test Format",
                    AuthorId = 1
                }
            );

            modelBuilder.Entity<AuthorEntity>()
                .OwnsOne(o => o.Address)
                .HasData(
                    new
                    {
                        OrganizationEntityId = 1,
                        City = "Kraków",
                        Street = "Św.Filipa 17",
                        PostalCode = "31-150"
                    }
                );

        }
    }
}
