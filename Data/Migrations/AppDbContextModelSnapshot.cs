﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("Data.Entities.AddressEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Address");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Kraków",
                            PostalCode = "31-150",
                            Street = "Św.Filipa 17"
                        },
                        new
                        {
                            Id = 2,
                            City = "Kraków",
                            PostalCode = "31-666",
                            Street = "Pod mostem"
                        });
                });

            modelBuilder.Entity("Data.Entities.AuthorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(120)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("AuthorEntity");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            Description = "Pierwszy author",
                            Name = "Author1"
                        },
                        new
                        {
                            Id = 2,
                            AddressId = 1,
                            Description = "Drugi author",
                            Name = "Author2"
                        },
                        new
                        {
                            Id = 3,
                            AddressId = 2,
                            Description = "Trzeci author",
                            Name = "Author3"
                        });
                });

            modelBuilder.Entity("Data.Entities.PhotoEntity", b =>
                {
                    b.Property<int>("PhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Camera")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(120)
                        .HasColumnType("TEXT");

                    b.Property<int>("Format")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Resolution")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("PhotoId");

                    b.HasIndex("AuthorId");

                    b.ToTable("photos");

                    b.HasData(
                        new
                        {
                            PhotoId = 1,
                            AuthorId = 1,
                            Camera = "Nikon",
                            CreatedDate = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Zdjęcie wykonane aparatem nikon",
                            Format = 0,
                            Resolution = "126x126"
                        },
                        new
                        {
                            PhotoId = 2,
                            AuthorId = 2,
                            Camera = "Sony",
                            CreatedDate = new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Zdjęcie wykonane aparatem sony",
                            Format = 1,
                            Resolution = "512x512"
                        },
                        new
                        {
                            PhotoId = 3,
                            AuthorId = 3,
                            Camera = "Red",
                            CreatedDate = new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Zdjęcie wykonane aparatem red",
                            Format = 2,
                            Resolution = "1024x1024"
                        });
                });

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
                            Id = "fe865148-3834-4b34-8f13-9f5d11f37893",
                            ConcurrencyStamp = "fe865148-3834-4b34-8f13-9f5d11f37893",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "5cd75b2f-2b01-4f28-b3eb-7d1d42d17b4c",
                            ConcurrencyStamp = "5cd75b2f-2b01-4f28-b3eb-7d1d42d17b4c",
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
                            Id = "769825a8-cdb6-4694-9cdf-f3c905273227",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "64789fa4-c3ae-4353-b859-a35a978ad853",
                            Email = "user@wsei.edu.pl",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@WSEI.EDU.PL",
                            NormalizedUserName = "USER",
                            PasswordHash = "AQAAAAIAAYagAAAAELaVuBRhAX5o97CUt1xyvQY5sMTIit2LEsam19ILOcxFAH/wDL/U7TOGi2rCK7nIpA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f586a0f0-22b0-4511-9376-522112465a44",
                            TwoFactorEnabled = false,
                            UserName = "user"
                        },
                        new
                        {
                            Id = "dfbace42-9d45-4144-840a-c8242799b052",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ba117028-2f87-47d3-ae1f-602b2331cbc5",
                            Email = "admin@wsei.edu.pl",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@WSEI.EDU.PL",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEPC3TojobZTavhxAIpipjx8l4ZE3iTOW5x8PdeG18Ov8utVnB/E7vXJIGJbID1yZgw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7a384f8a-9539-46f9-8ca7-8226966d7460",
                            TwoFactorEnabled = false,
                            UserName = "admin"
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
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
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
                            UserId = "769825a8-cdb6-4694-9cdf-f3c905273227",
                            RoleId = "5cd75b2f-2b01-4f28-b3eb-7d1d42d17b4c"
                        },
                        new
                        {
                            UserId = "dfbace42-9d45-4144-840a-c8242799b052",
                            RoleId = "fe865148-3834-4b34-8f13-9f5d11f37893"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Data.Entities.AuthorEntity", b =>
                {
                    b.HasOne("Data.Entities.AddressEntity", "Address")
                        .WithMany("Authors")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Data.Entities.PhotoEntity", b =>
                {
                    b.HasOne("Data.Entities.AuthorEntity", "Author")
                        .WithMany("Photos")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
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

            modelBuilder.Entity("Data.Entities.AddressEntity", b =>
                {
                    b.Navigation("Authors");
                });

            modelBuilder.Entity("Data.Entities.AuthorEntity", b =>
                {
                    b.Navigation("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}
