using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProjektZaliczeniowy.Models.Movies;

public partial class MoviesContext : IdentityDbContext<IdentityUser>
{
    public MoviesContext()
    {
    }

    public MoviesContext(DbContextOptions<MoviesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Keyword> Keywords { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<LanguageRole> LanguageRoles { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<MovieCast> MovieCasts { get; set; }

    public virtual DbSet<MovieCompany> MovieCompanies { get; set; }

    public virtual DbSet<MovieCrew> MovieCrews { get; set; }

    public virtual DbSet<MovieGenre> MovieGenres { get; set; }

    public virtual DbSet<MovieKeyword> MovieKeywords { get; set; }

    public virtual DbSet<MovieLanguage> MovieLanguages { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<ProductionCompany> ProductionCompanies { get; set; }

    public virtual DbSet<ProductionCountry> ProductionCountries { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
            
        string ADMIN_ID = Guid.NewGuid().ToString();
        string ADMIN_ROLE_ID = Guid.NewGuid().ToString();
        
        string USER_ID = Guid.NewGuid().ToString();
        string USER_ROLE_ID = Guid.NewGuid().ToString();

        
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
        
        PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
        admin.PasswordHash = ph.HashPassword(admin, "1234abcd!@#$ABCD");
        user.PasswordHash = ph.HashPassword(user, "abcde1234!@#$ABCD");
        
        modelBuilder.Entity<IdentityUser>().HasData(admin);
        modelBuilder.Entity<IdentityUser>().HasData(user);
        
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
        
        modelBuilder.Entity<Country>().ToTable("country", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<Department>().ToTable("department", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<Gender>().ToTable("gender", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<Genre>().ToTable("genre", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<Keyword>().ToTable("keyword", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<Language>().ToTable("language", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<LanguageRole>().ToTable("language_role", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<Movie>().ToTable("movie", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<MovieCast>().ToTable("movie_cast", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<MovieCompany>().ToTable("movie_company", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<MovieCrew>().ToTable("movie_crew", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<MovieGenre>().ToTable("movie_genres", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<MovieKeyword>().ToTable("movie_keywords", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<MovieLanguage>().ToTable("movie_languages", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<Person>().ToTable("person", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<ProductionCompany>().ToTable("production_company", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<ProductionCountry>().ToTable("production_country", t => t.ExcludeFromMigrations());
        
        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("country");

            entity.Property(e => e.CountryId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("country_id");
            entity.Property(e => e.CountryIsoCode)
                .HasDefaultValueSql("NULL")
                .HasColumnName("country_iso_code");
            entity.Property(e => e.CountryName)
                .HasDefaultValueSql("NULL")
                .HasColumnName("country_name");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("department");

            entity.Property(e => e.DepartmentId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("department_id");
            entity.Property(e => e.DepartmentName)
                .HasDefaultValueSql("NULL")
                .HasColumnName("department_name");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.ToTable("gender");

            entity.Property(e => e.GenderId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("gender_id");
            entity.Property(e => e.Gender1)
                .HasDefaultValueSql("NULL")
                .HasColumnName("gender");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("genre");

            entity.Property(e => e.GenreId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("genre_id");
            entity.Property(e => e.GenreName)
                .HasDefaultValueSql("NULL")
                .HasColumnName("genre_name");
        });

        modelBuilder.Entity<Keyword>(entity =>
        {
            entity.ToTable("keyword");

            entity.Property(e => e.KeywordId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("keyword_id");
            entity.Property(e => e.KeywordName)
                .HasDefaultValueSql("NULL")
                .HasColumnType("varchar(100)")
                .HasColumnName("keyword_name");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.ToTable("language");

            entity.Property(e => e.LanguageId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("language_id");
            entity.Property(e => e.LanguageCode)
                .HasDefaultValueSql("NULL")
                .HasColumnName("language_code");
            entity.Property(e => e.LanguageName)
                .HasDefaultValueSql("NULL")
                .HasColumnName("language_name");
        });

        modelBuilder.Entity<LanguageRole>(entity =>
        {
            entity.HasKey(e => e.RoleId);

            entity.ToTable("language_role");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("role_id");
            entity.Property(e => e.LanguageRole1)
                .HasDefaultValueSql("NULL")
                .HasColumnName("language_role");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.ToTable("movie");

            entity.Property(e => e.MovieId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("movie_id");
            entity.Property(e => e.Budget)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("budget");
            entity.Property(e => e.Homepage)
                .HasDefaultValueSql("NULL")
                .HasColumnName("homepage");
            entity.Property(e => e.MovieStatus)
                .HasDefaultValueSql("NULL")
                .HasColumnName("movie_status");
            entity.Property(e => e.Overview)
                .HasDefaultValueSql("NULL")
                .HasColumnName("overview");
            entity.Property(e => e.Popularity)
                .HasDefaultValueSql("NULL")
                .HasColumnName("popularity");
            entity.Property(e => e.ReleaseDate)
                .HasDefaultValueSql("NULL")
                .HasColumnType("DATE")
                .HasColumnName("release_date");
            entity.Property(e => e.Revenue)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("revenue");
            entity.Property(e => e.Runtime)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("runtime");
            entity.Property(e => e.Tagline)
                .HasDefaultValueSql("NULL")
                .HasColumnName("tagline");
            entity.Property(e => e.Title)
                .HasDefaultValueSql("NULL")
                .HasColumnName("title");
            entity.Property(e => e.VoteAverage)
                .HasDefaultValueSql("NULL")
                .HasColumnName("vote_average");
            entity.Property(e => e.VoteCount)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("vote_count");
        });

        modelBuilder.Entity<MovieCast>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("movie_cast");

            entity.Property(e => e.CastOrder)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("cast_order");
            entity.Property(e => e.CharacterName)
                .HasDefaultValueSql("NULL")
                .HasColumnName("character_name");
            entity.Property(e => e.GenderId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("gender_id");
            entity.Property(e => e.MovieId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("movie_id");
            entity.Property(e => e.PersonId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("person_id");

            entity.HasOne(d => d.Gender).WithMany().HasForeignKey(d => d.GenderId);

            entity.HasOne(d => d.Movie).WithMany().HasForeignKey(d => d.MovieId);

            entity.HasOne(d => d.Person).WithMany().HasForeignKey(d => d.PersonId);
        });

        modelBuilder.Entity<MovieCompany>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("movie_company");

            entity.Property(e => e.CompanyId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("company_id");
            entity.Property(e => e.MovieId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("movie_id");

            entity.HasOne(d => d.Company).WithMany().HasForeignKey(d => d.CompanyId);

            entity.HasOne(d => d.Movie).WithMany().HasForeignKey(d => d.MovieId);
        });

        modelBuilder.Entity<MovieCrew>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("movie_crew");

            entity.Property(e => e.DepartmentId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("department_id");
            entity.Property(e => e.Job)
                .HasDefaultValueSql("NULL")
                .HasColumnName("job");
            entity.Property(e => e.MovieId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("movie_id");
            entity.Property(e => e.PersonId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("person_id");

            entity.HasOne(d => d.Department).WithMany().HasForeignKey(d => d.DepartmentId);

            entity.HasOne(d => d.Movie).WithMany().HasForeignKey(d => d.MovieId);

            entity.HasOne(d => d.Person).WithMany().HasForeignKey(d => d.PersonId);
        });

        modelBuilder.Entity<MovieGenre>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("movie_genres");

            entity.Property(e => e.GenreId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("genre_id");
            entity.Property(e => e.MovieId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("movie_id");

            entity.HasOne(d => d.Genre).WithMany().HasForeignKey(d => d.GenreId);

            entity.HasOne(d => d.Movie).WithMany().HasForeignKey(d => d.MovieId);
        });

        modelBuilder.Entity<MovieKeyword>(entity =>
        {
            entity
                .HasKey(mk => new { mk.MovieId, mk.KeywordId });
            
            entity
                .ToTable("movie_keywords");

            entity.Property(e => e.KeywordId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("keyword_id");
            entity.Property(e => e.MovieId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("movie_id");

            entity.HasOne(d => d.Keyword).WithMany().HasForeignKey(d => d.KeywordId);

            entity.HasOne(d => d.Movie).WithMany().HasForeignKey(d => d.MovieId);
        });

        modelBuilder.Entity<MovieLanguage>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("movie_languages");

            entity.Property(e => e.LanguageId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("language_id");
            entity.Property(e => e.LanguageRoleId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("language_role_id");
            entity.Property(e => e.MovieId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("movie_id");

            entity.HasOne(d => d.Language).WithMany().HasForeignKey(d => d.LanguageId);

            entity.HasOne(d => d.LanguageRole).WithMany().HasForeignKey(d => d.LanguageRoleId);

            entity.HasOne(d => d.Movie).WithMany().HasForeignKey(d => d.MovieId);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("person");

            entity.Property(e => e.PersonId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("person_id");
            entity.Property(e => e.PersonName)
                .HasDefaultValueSql("NULL")
                .HasColumnName("person_name");
        });

        modelBuilder.Entity<ProductionCompany>(entity =>
        {
            entity.HasKey(e => e.CompanyId);

            entity.ToTable("production_company");

            entity.Property(e => e.CompanyId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("company_id");
            entity.Property(e => e.CompanyName)
                .HasDefaultValueSql("NULL")
                .HasColumnName("company_name");
        });

        modelBuilder.Entity<ProductionCountry>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("production_country");

            entity.Property(e => e.CountryId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("country_id");
            entity.Property(e => e.MovieId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("movie_id");

            entity.HasOne(d => d.Country).WithMany().HasForeignKey(d => d.CountryId);

            entity.HasOne(d => d.Movie).WithMany().HasForeignKey(d => d.MovieId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
