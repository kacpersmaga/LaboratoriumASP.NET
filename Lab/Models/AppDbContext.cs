using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lab.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }

        private string DbPath { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "contacts.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            string ADMIN_ID = Guid.NewGuid().ToString();
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();
            
            string USER_ID = Guid.NewGuid().ToString();
            string USER_ROLE_ID = Guid.NewGuid().ToString();


            // dodanie roli administratora
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "ADMIN",
                    Id = ADMIN_ROLE_ID,
                    ConcurrencyStamp = ADMIN_ROLE_ID
                },
                new IdentityRole
                {
                    Name = "user",
                    NormalizedName = "USER",
                    Id = USER_ROLE_ID,
                    ConcurrencyStamp = USER_ROLE_ID
                }
            );

            // utworzenie administratora jako użytkownika
            var admin = new IdentityUser
            {
                Id = ADMIN_ID,
                Email = "adam@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                NormalizedEmail = "ADAM@WSEI.EDU.PL"
            };
            
            var user = new IdentityUser
            {
                Id = USER_ID,
                Email = "damian@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "user",
                NormalizedUserName = "USER",
                NormalizedEmail = "DAMIAN@WSEI.EDU.PL"
            };

            // haszowanie hasła, najlepiej wykonać to poza programem i zapisać gotowy
            // PasswordHash
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = ph.HashPassword(admin, "1234abcd!@#$ABCD");
            user.PasswordHash = ph.HashPassword(user, "abcde1234!@#$ABCD");

            // zapisanie użytkownika
            modelBuilder.Entity<IdentityUser>().HasData(admin);
            modelBuilder.Entity<IdentityUser>().HasData(user);

            // przypisanie roli administratora użytkownikowi
            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_ID
                });
            
            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID
                });
            
            modelBuilder.Entity<ContactEntity>()
                .HasOne(e => e.Organization)
                .WithMany(o => o.Contacts)
                .HasForeignKey(e => e.OrganizationId);

            modelBuilder.Entity<OrganizationEntity>()
                .OwnsOne(e => e.Address);
            
            modelBuilder.Entity<OrganizationEntity>()
                .ToTable("organizations")
                .HasData(
                    new OrganizationEntity
                    {
                        Id = 101,
                        Title = "WSEI",
                        Nip = "83492384",
                        Regon = "13424234"
                    },
                    new OrganizationEntity
                    {
                        Id = 102,
                        Title = "Firma",
                        Nip = "2498534",
                        Regon = "0873439249"
                    }
                );
            
            modelBuilder.Entity<OrganizationEntity>()
                .OwnsOne(e => e.Address)
                .HasData(
                    new { OrganizationEntityId = 101, City = "Kraków", Street = "Św. Filipa 17", PostalCode = "31-150", Region = "małopolskie" },
                    new { OrganizationEntityId = 102, City = "Kraków", Street = "Krowoderska 45/6", PostalCode = "31-150", Region = "małopolskie" }
                );
            
            modelBuilder.Entity<ContactEntity>()
                .HasData(
                    new ContactEntity
                    {
                        Id = 1,
                        FirstName = "Adam",
                        LastName = "Kowal",
                        BirthDate = new DateOnly(2000, 10, 10),
                        PhoneNumber = "+48 987 654 321",
                        Email = "adam@wsei.pl",
                        Category = Category.Business,
                        Created = DateTime.Now,
                        OrganizationId = 101
                    },
                    new ContactEntity
                    {
                        Id = 2,
                        FirstName = "Ewa",
                        LastName = "Kowal",
                        BirthDate = new DateOnly(2001, 10, 10),
                        PhoneNumber = "+48 123 456 789",
                        Email = "ewa@wsei.pl",
                        Category = Category.Family,
                        Created = DateTime.Now,
                        OrganizationId = 102
                    }
                );
            
            modelBuilder.Entity<ContactEntity>()
                .Property(e => e.OrganizationId)
                .HasDefaultValue(101);

            modelBuilder.Entity<ContactEntity>()
                .Property(e => e.Created)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");


        }
    }
}
