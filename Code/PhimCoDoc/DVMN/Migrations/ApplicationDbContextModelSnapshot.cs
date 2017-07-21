using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DVMN.Data;

namespace DVMN.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DVMN.Models.FeedbackTranslate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Active");

                    b.Property<string>("Approved");

                    b.Property<string>("AuthorID");

                    b.Property<DateTime?>("CreateDT");

                    b.Property<int>("FilmID");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<string>("Note");

                    b.Property<string>("TimeError");

                    b.Property<DateTime?>("UpdateDT");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.HasIndex("FilmID");

                    b.ToTable("FeedbackTranslate");
                });

            modelBuilder.Entity("DVMN.Models.Film", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Active");

                    b.Property<string>("Actor");

                    b.Property<string>("Approved");

                    b.Property<string>("AuthorID");

                    b.Property<DateTime?>("CreateDT");

                    b.Property<DateTime?>("DateofRease");

                    b.Property<string>("Description");

                    b.Property<string>("DescriptionShort");

                    b.Property<string>("Director");

                    b.Property<string>("Genres");

                    b.Property<int?>("ImageID");

                    b.Property<string>("Info");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsProposed");

                    b.Property<string>("Length");

                    b.Property<string>("Note");

                    b.Property<string>("OrtherTitle");

                    b.Property<int?>("SerieID");

                    b.Property<string>("Slug");

                    b.Property<float>("StarRating");

                    b.Property<string>("Title");

                    b.Property<DateTime?>("UpdateDT");

                    b.Property<string>("Video");

                    b.Property<string>("VideoBackUp1");

                    b.Property<string>("VideoBackUp2");

                    b.Property<string>("VideoTrailer");

                    b.Property<int>("Vote");

                    b.Property<int>("Watch");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.HasIndex("ImageID");

                    b.HasIndex("SerieID");

                    b.ToTable("Film");
                });

            modelBuilder.Entity("DVMN.Models.Images", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ALT");

                    b.Property<string>("Active");

                    b.Property<string>("Approved");

                    b.Property<string>("AuthorID");

                    b.Property<DateTime?>("CreateDT");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<string>("Note");

                    b.Property<string>("Pic1140x641");

                    b.Property<string>("Pic115x175");

                    b.Property<string>("Pic1300x500");

                    b.Property<string>("Pic182x268");

                    b.Property<string>("Pic268x268");

                    b.Property<string>("Pic640x351");

                    b.Property<string>("Title");

                    b.Property<DateTime?>("UpdateDT");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("DVMN.Models.Member", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("DateofBirth");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Facebook");

                    b.Property<string>("FullName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("PictureBig");

                    b.Property<string>("PictureSmall");

                    b.Property<int>("Score");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("DVMN.Models.ProposalsFilm", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Active");

                    b.Property<string>("Approved");

                    b.Property<string>("AuthorID");

                    b.Property<DateTime?>("CreateDT");

                    b.Property<int?>("ImageID");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<string>("Note");

                    b.Property<string>("Reason");

                    b.Property<DateTime?>("UpdateDT");

                    b.Property<int>("Vote");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.HasIndex("ImageID");

                    b.ToTable("ProposalsFilm");
                });

            modelBuilder.Entity("DVMN.Models.Serie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Active");

                    b.Property<string>("Approved");

                    b.Property<string>("AuthorID");

                    b.Property<DateTime?>("CreateDT");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<string>("Note");

                    b.Property<string>("Slug");

                    b.Property<DateTime?>("UpdateDT");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.ToTable("Serie");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DVMN.Models.FeedbackTranslate", b =>
                {
                    b.HasOne("DVMN.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("AuthorID");

                    b.HasOne("DVMN.Models.Film", "Film")
                        .WithMany()
                        .HasForeignKey("FilmID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DVMN.Models.Film", b =>
                {
                    b.HasOne("DVMN.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("AuthorID");

                    b.HasOne("DVMN.Models.Images", "Image")
                        .WithMany()
                        .HasForeignKey("ImageID");

                    b.HasOne("DVMN.Models.Serie", "Serie")
                        .WithMany()
                        .HasForeignKey("SerieID");
                });

            modelBuilder.Entity("DVMN.Models.Images", b =>
                {
                    b.HasOne("DVMN.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("AuthorID");
                });

            modelBuilder.Entity("DVMN.Models.ProposalsFilm", b =>
                {
                    b.HasOne("DVMN.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("AuthorID");

                    b.HasOne("DVMN.Models.Images", "Image")
                        .WithMany()
                        .HasForeignKey("ImageID");
                });

            modelBuilder.Entity("DVMN.Models.Serie", b =>
                {
                    b.HasOne("DVMN.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("AuthorID");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DVMN.Models.Member")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DVMN.Models.Member")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DVMN.Models.Member")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
