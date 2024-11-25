using Microsoft.EntityFrameworkCore;

namespace Lab.Models
{
    public class AppDbContext : DbContext
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
