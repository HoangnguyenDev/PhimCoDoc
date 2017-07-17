using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DVMN.Data;

namespace DVMN.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170714030452_Init4")]
    partial class Init4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DVMN.Models.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Active");

                    b.Property<string>("Approved");

                    b.Property<DateTime?>("CreateDT");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("Like");

                    b.Property<int>("MMultiPuzzle");

                    b.Property<string>("MemberID");

                    b.Property<int?>("MultiPuzzleID");

                    b.Property<string>("Note");

                    b.Property<int?>("SSinglePuzzleID");

                    b.Property<DateTime?>("UpdateDT");

                    b.HasKey("ID");

                    b.HasIndex("MemberID");

                    b.HasIndex("MultiPuzzleID");

                    b.HasIndex("SSinglePuzzleID");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("DVMN.Models.Image", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ALT");

                    b.Property<string>("Active");

                    b.Property<string>("Approved");

                    b.Property<DateTime?>("CreateDT");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("MemberID");

                    b.Property<string>("Note");

                    b.Property<string>("Pic1");

                    b.Property<string>("Pic2");

                    b.Property<string>("Pic3");

                    b.Property<string>("Title");

                    b.Property<DateTime?>("UpdateDT");

                    b.HasKey("ID");

                    b.HasIndex("MemberID");

                    b.ToTable("Image");
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

            modelBuilder.Entity("DVMN.Models.MMultiPuzzle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Active");

                    b.Property<string>("Approved");

                    b.Property<DateTime?>("CreateDT");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Image");

                    b.Property<bool>("IsDeleted");

                    b.Property<float>("Level");

                    b.Property<int>("Like");

                    b.Property<string>("MemberID");

                    b.Property<string>("Note");

                    b.Property<int>("NumberQuestion");

                    b.Property<string>("Slug")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<DateTime?>("UpdateDT");

                    b.HasKey("ID");

                    b.HasIndex("MemberID");

                    b.ToTable("MultiPuzzle");
                });

            modelBuilder.Entity("DVMN.Models.MSinglePuzzleDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Active");

                    b.Property<string>("AnswerA");

                    b.Property<string>("AnswerB");

                    b.Property<string>("AnswerC");

                    b.Property<string>("AnswerD");

                    b.Property<string>("Approved");

                    b.Property<int>("Correct");

                    b.Property<DateTime?>("CreateDT");

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsYesNo");

                    b.Property<int>("MMultiPuzzleID");

                    b.Property<string>("MemberID");

                    b.Property<string>("Note");

                    b.Property<string>("Reason");

                    b.Property<string>("Title");

                    b.Property<DateTime?>("UpdateDT");

                    b.HasKey("ID");

                    b.HasIndex("MMultiPuzzleID");

                    b.HasIndex("MemberID");

                    b.ToTable("SinglePuzzleDetails");
                });

            modelBuilder.Entity("DVMN.Models.SSinglePuzzle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Active");

                    b.Property<string>("AnswerA");

                    b.Property<string>("AnswerB");

                    b.Property<string>("AnswerC");

                    b.Property<string>("AnswerD");

                    b.Property<string>("Approved");

                    b.Property<int>("Correct");

                    b.Property<DateTime?>("CreateDT");

                    b.Property<string>("Description");

                    b.Property<int>("ImageID");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsYesNo");

                    b.Property<float>("Level");

                    b.Property<int>("Like");

                    b.Property<string>("MemberID");

                    b.Property<string>("Note");

                    b.Property<string>("Reason");

                    b.Property<string>("Slug");

                    b.Property<string>("Title");

                    b.Property<DateTime?>("UpdateDT");

                    b.HasKey("ID");

                    b.HasIndex("ImageID");

                    b.HasIndex("MemberID");

                    b.ToTable("SSinglePuzzle");
                });

            modelBuilder.Entity("DVMN.Models.Tag", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Active");

                    b.Property<string>("Approved");

                    b.Property<DateTime?>("CreateDT");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("MemberID");

                    b.Property<string>("Name");

                    b.Property<string>("Note");

                    b.Property<string>("SinglePuzzleDetailsID");

                    b.Property<int?>("SinglePuzzleDetailsID1");

                    b.Property<string>("Slug");

                    b.Property<DateTime?>("UpdateDT");

                    b.HasKey("ID");

                    b.HasIndex("MemberID");

                    b.HasIndex("SinglePuzzleDetailsID1");

                    b.ToTable("Tag");
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

            modelBuilder.Entity("DVMN.Models.Comment", b =>
                {
                    b.HasOne("DVMN.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberID");

                    b.HasOne("DVMN.Models.MMultiPuzzle", "MultiPuzzle")
                        .WithMany("Comment")
                        .HasForeignKey("MultiPuzzleID");

                    b.HasOne("DVMN.Models.SSinglePuzzle")
                        .WithMany("Comment")
                        .HasForeignKey("SSinglePuzzleID");
                });

            modelBuilder.Entity("DVMN.Models.Image", b =>
                {
                    b.HasOne("DVMN.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberID");
                });

            modelBuilder.Entity("DVMN.Models.MMultiPuzzle", b =>
                {
                    b.HasOne("DVMN.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberID");
                });

            modelBuilder.Entity("DVMN.Models.MSinglePuzzleDetails", b =>
                {
                    b.HasOne("DVMN.Models.MMultiPuzzle", "MultiPuzzle")
                        .WithMany("SinglePuzzleDetails")
                        .HasForeignKey("MMultiPuzzleID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DVMN.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberID");
                });

            modelBuilder.Entity("DVMN.Models.SSinglePuzzle", b =>
                {
                    b.HasOne("DVMN.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DVMN.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberID");
                });

            modelBuilder.Entity("DVMN.Models.Tag", b =>
                {
                    b.HasOne("DVMN.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberID");

                    b.HasOne("DVMN.Models.MSinglePuzzleDetails", "SinglePuzzleDetails")
                        .WithMany()
                        .HasForeignKey("SinglePuzzleDetailsID1");
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
