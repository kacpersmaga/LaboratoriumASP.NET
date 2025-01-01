﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjektZaliczeniowy.Models.Movies;

#nullable disable

namespace ProjektZaliczeniowy.Models.Movies
{
    [DbContext(typeof(MoviesContext))]
    [Migration("20250101213839_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "db473a84-5f45-4b84-966f-98bb2cd16841",
                            ConcurrencyStamp = "db473a84-5f45-4b84-966f-98bb2cd16841",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "0bbaa92d-a859-4d2a-b0b7-fe4806a664e5",
                            ConcurrencyStamp = "0bbaa92d-a859-4d2a-b0b7-fe4806a664e5",
                            Name = "user",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1edc8a17-68df-4aad-ae6e-4d2f37691b77",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "61af5a74-b73d-46de-b3af-20ff4e0164f1",
                            Email = "adam@wsei.edu.pl",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADAM@WSEI.EDU.PL",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEM7JC/OfMQBoEy007orkJL3sWgjHNiZmXeAAPopw0JzWL3IvHWTYRuJVl143oiYJkQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5caf705d-b064-4192-b99a-03b2d34ba7aa",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = "5479cc02-e105-4e35-8783-ca50cb4107e6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d484f197-334c-4782-b6e9-6027784b406e",
                            Email = "damian@wsei.edu.pl",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "DAMIAN@WSEI.EDU.PL",
                            NormalizedUserName = "USER",
                            PasswordHash = "AQAAAAIAAYagAAAAEMoqhL4PRmYILrcb8ueYP0NKmLuAGC5Vp8jY/3Vt9ZZ0dkO3pUxvppDYMUZV2OtK4A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6f795d94-6496-4522-8304-a8a2e167b7e5",
                            TwoFactorEnabled = false,
                            UserName = "user"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "1edc8a17-68df-4aad-ae6e-4d2f37691b77",
                            RoleId = "db473a84-5f45-4b84-966f-98bb2cd16841"
                        },
                        new
                        {
                            UserId = "5479cc02-e105-4e35-8783-ca50cb4107e6",
                            RoleId = "0bbaa92d-a859-4d2a-b0b7-fe4806a664e5"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Movies.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .HasColumnType("INT")
                        .HasColumnName("country_id");

                    b.Property<string>("CountryIsoCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("country_iso_code")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("CountryName")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("country_name")
                        .HasDefaultValueSql("NULL");

                    b.HasKey("CountryId");

                    b.ToTable("country", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Movies.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .HasColumnType("INT")
                        .HasColumnName("department_id");

                    b.Property<string>("DepartmentName")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("department_name")
                        .HasDefaultValueSql("NULL");

                    b.HasKey("DepartmentId");

                    b.ToTable("department", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Movies.Gender", b =>
                {
                    b.Property<int>("GenderId")
                        .HasColumnType("INT")
                        .HasColumnName("gender_id");

                    b.Property<string>("Gender1")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("gender")
                        .HasDefaultValueSql("NULL");

                    b.HasKey("GenderId");

                    b.ToTable("gender", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Movies.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .HasColumnType("INT")
                        .HasColumnName("genre_id");

                    b.Property<string>("GenreName")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("genre_name")
                        .HasDefaultValueSql("NULL");

                    b.HasKey("GenreId");

                    b.ToTable("genre", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Movies.Keyword", b =>
                {
                    b.Property<int>("KeywordId")
                        .HasColumnType("INT")
                        .HasColumnName("keyword_id");

                    b.Property<string>("KeywordName")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("keyword_name")
                        .HasDefaultValueSql("NULL");

                    b.HasKey("KeywordId");

                    b.ToTable("keyword", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Movies.Language", b =>
                {
                    b.Property<int>("LanguageId")
                        .HasColumnType("INT")
                        .HasColumnName("language_id");

                    b.Property<string>("LanguageCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("language_code")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("LanguageName")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("language_name")
                        .HasDefaultValueSql("NULL");

                    b.HasKey("LanguageId");

                    b.ToTable("language", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Movies.LanguageRole", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("INT")
                        .HasColumnName("role_id");

                    b.Property<string>("LanguageRole1")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("language_role")
                        .HasDefaultValueSql("NULL");

                    b.HasKey("RoleId");

                    b.ToTable("language_role", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Movies.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("INT")
                        .HasColumnName("movie_id");

                    b.Property<int?>("Budget")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("budget")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Homepage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("homepage")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("MovieStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("movie_status")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Overview")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("overview")
                        .HasDefaultValueSql("NULL");

                    b.Property<double?>("Popularity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("REAL")
                        .HasColumnName("popularity")
                        .HasDefaultValueSql("NULL");

                    b.Property<DateOnly?>("ReleaseDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATE")
                        .HasColumnName("release_date")
                        .HasDefaultValueSql("NULL");

                    b.Property<long?>("Revenue")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("revenue")
                        .HasDefaultValueSql("NULL");

                    b.Property<int?>("Runtime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("runtime")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Tagline")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("tagline")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Title")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("title")
                        .HasDefaultValueSql("NULL");

                    b.Property<double?>("VoteAverage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("REAL")
                        .HasColumnName("vote_average")
                        .HasDefaultValueSql("NULL");

                    b.Property<int?>("VoteCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("vote_count")
                        .HasDefaultValueSql("NULL");

                    b.HasKey("MovieId");

                    b.ToTable("movie", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Movies.MovieCast", b =>
                {
                    b.Property<int?>("CastOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("cast_order")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("CharacterName")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("character_name")
                        .HasDefaultValueSql("NULL");

                    b.Property<int?>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("gender_id")
                        .HasDefaultValueSql("NULL");

                    b.Property<int?>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("movie_id")
                        .HasDefaultValueSql("NULL");

                    b.Property<int?>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("person_id")
                        .HasDefaultValueSql("NULL");

                    b.HasIndex("GenderId");

                    b.HasIndex("MovieId");

                    b.HasIndex("PersonId");

                    b.ToTable("movie_cast", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Movies.MovieCompany", b =>
                {
                    b.Property<int?>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("company_id")
                        .HasDefaultValueSql("NULL");

                    b.Property<int?>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("movie_id")
                        .HasDefaultValueSql("NULL");

                    b.HasIndex("CompanyId");

                    b.HasIndex("MovieId");

                    b.ToTable("movie_company", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Movies.MovieCrew", b =>
                {
                    b.Property<int?>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("department_id")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Job")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("job")
                        .HasDefaultValueSql("NULL");

                    b.Property<int?>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("movie_id")
                        .HasDefaultValueSql("NULL");

                    b.Property<int?>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("person_id")
                        .HasDefaultValueSql("NULL");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("MovieId");

                    b.HasIndex("PersonId");

                    b.ToTable("movie_crew", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Movies.MovieGenre", b =>
                {
                    b.Property<int?>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("genre_id")
                        .HasDefaultValueSql("NULL");

                    b.Property<int?>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("movie_id")
                        .HasDefaultValueSql("NULL");

                    b.HasIndex("GenreId");

                    b.HasIndex("MovieId");

                    b.ToTable("movie_genres", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Movies.MovieKeyword", b =>
                {
                    b.Property<int?>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("movie_id")
                        .HasDefaultValueSql("NULL");

                    b.Property<int?>("KeywordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("keyword_id")
                        .HasDefaultValueSql("NULL");

                    b.HasKey("MovieId", "KeywordId");

                    b.HasIndex("KeywordId");

                    b.ToTable("movie_keywords", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Movies.MovieLanguage", b =>
                {
                    b.Property<int?>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("language_id")
                        .HasDefaultValueSql("NULL");

                    b.Property<int?>("LanguageRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("language_role_id")
                        .HasDefaultValueSql("NULL");

                    b.Property<int?>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("movie_id")
                        .HasDefaultValueSql("NULL");

                    b.HasIndex("LanguageId");

                    b.HasIndex("LanguageRoleId");

                    b.HasIndex("MovieId");

                    b.ToTable("movie_languages", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Movies.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("INT")
                        .HasColumnName("person_id");

                    b.Property<string>("PersonName")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("person_name")
                        .HasDefaultValueSql("NULL");

                    b.HasKey("PersonId");

                    b.ToTable("person", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Movies.ProductionCompany", b =>
                {
                    b.Property<int>("CompanyId")
                        .HasColumnType("INT")
                        .HasColumnName("company_id");

                    b.Property<string>("CompanyName")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("company_name")
                        .HasDefaultValueSql("NULL");

                    b.HasKey("CompanyId");

                    b.ToTable("production_company", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Movies.ProductionCountry", b =>
                {
                    b.Property<int?>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("country_id")
                        .HasDefaultValueSql("NULL");

                    b.Property<int?>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("movie_id")
                        .HasDefaultValueSql("NULL");

                    b.HasIndex("CountryId");

                    b.HasIndex("MovieId");

                    b.ToTable("production_country", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Movies.MovieCast", b =>
                {
                    b.HasOne("ProjektZaliczeniowy.Models.Movies.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId");

                    b.HasOne("ProjektZaliczeniowy.Models.Movies.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId");

                    b.HasOne("ProjektZaliczeniowy.Models.Movies.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.Navigation("Gender");

                    b.Navigation("Movie");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Movies.MovieCompany", b =>
                {
                    b.HasOne("ProjektZaliczeniowy.Models.Movies.ProductionCompany", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("ProjektZaliczeniowy.Models.Movies.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId");

                    b.Navigation("Company");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Movies.MovieCrew", b =>
                {
                    b.HasOne("ProjektZaliczeniowy.Models.Movies.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("ProjektZaliczeniowy.Models.Movies.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId");

                    b.HasOne("ProjektZaliczeniowy.Models.Movies.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.Navigation("Department");

                    b.Navigation("Movie");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Movies.MovieGenre", b =>
                {
                    b.HasOne("ProjektZaliczeniowy.Models.Movies.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId");

                    b.HasOne("ProjektZaliczeniowy.Models.Movies.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId");

                    b.Navigation("Genre");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Movies.MovieKeyword", b =>
                {
                    b.HasOne("ProjektZaliczeniowy.Models.Movies.Keyword", "Keyword")
                        .WithMany()
                        .HasForeignKey("KeywordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjektZaliczeniowy.Models.Movies.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Keyword");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Movies.MovieLanguage", b =>
                {
                    b.HasOne("ProjektZaliczeniowy.Models.Movies.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId");

                    b.HasOne("ProjektZaliczeniowy.Models.Movies.LanguageRole", "LanguageRole")
                        .WithMany()
                        .HasForeignKey("LanguageRoleId");

                    b.HasOne("ProjektZaliczeniowy.Models.Movies.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId");

                    b.Navigation("Language");

                    b.Navigation("LanguageRole");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Movies.ProductionCountry", b =>
                {
                    b.HasOne("ProjektZaliczeniowy.Models.Movies.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("ProjektZaliczeniowy.Models.Movies.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId");

                    b.Navigation("Country");

                    b.Navigation("Movie");
                });
#pragma warning restore 612, 618
        }
    }
}
