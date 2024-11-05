using Microsoft.EntityFrameworkCore;

namespace Lab.Models;

public class AppDbContext: DbContext
{
    public DbSet<ContactEntity> Contacts { get; set; }
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
            .HasData(
                new ContactEntity()
                {
                    Id = 1,
                    FirstName = "Adam",
                    LastName = "Kowal",
                    BirthDate = new DateOnly(2000,10,10),
                    PhoneNumber = "987654321",
                    Email = "adam@wsei.pl",
                    Category = Category.Business,
                    Created = DateTime.Now
                    
                },
                new ContactEntity()
                    {
                        Id = 2,
                        FirstName = "Ewa",
                        LastName = "Kowal",
                        BirthDate = new DateOnly(2001,10,10),
                        PhoneNumber = "123456789",
                        Email = "ewa@wsei.pl",
                        Category = Category.Family,
                        Created = DateTime.Now
                            
                    }
            );
    }
}