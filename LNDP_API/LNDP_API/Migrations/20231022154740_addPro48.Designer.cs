﻿// <auto-generated />
using System;
using LNDP_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LNDP_API.Migrations
{
    [DbContext(typeof(APIContext))]
    [Migration("20231022154740_addPro48")]
    partial class addPro48
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LNDP_API.Models.Acces", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Acces");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PasswordHash = "g7xvkO0+id5be1Ah3TnFR3esYlPt1Xrgf6YoOacPO5w=",
                            PasswordSalt = "7NB/yHGSwLpPMAQ62sfmyw==",
                            UserName = "Sanchez"
                        },
                        new
                        {
                            Id = 2,
                            PasswordHash = "mhA1h1lzHUV+wSLXiXiJug2hQ2iqprb62IZUhADYYk4=",
                            PasswordSalt = "7NB/yHGSwLpPMAQ62sfmyw==",
                            UserName = "Torres"
                        },
                        new
                        {
                            Id = 3,
                            PasswordHash = "0SIa189UTQjFViOzEZJVWiZwsmu8ufUJmyHDQ9o1Uwg=",
                            PasswordSalt = "7NB/yHGSwLpPMAQ62sfmyw==",
                            UserName = "Tomas"
                        },
                        new
                        {
                            Id = 4,
                            PasswordHash = "lfl+3z0JRIlpRjUoiOyoVWJ0YuZEufDpA6In1AfEUwY=",
                            PasswordSalt = "7NB/yHGSwLpPMAQ62sfmyw==",
                            UserName = "Iglesias"
                        });
                });

            modelBuilder.Entity("LNDP_API.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ArtistId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WebUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("LNDP_API.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("CommunicationEmail")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("text");

                    b.Property<string>("RecruitmentEmail")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("LNDP_API.Models.ArtistFestivalAsoc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ArtistId")
                        .HasColumnType("integer");

                    b.Property<int>("FestivalId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("FestivalId");

                    b.ToTable("ArtistFestivalAsoc");
                });

            modelBuilder.Entity("LNDP_API.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("text");

                    b.Property<string>("WebUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompanyTypeId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("LNDP_API.Models.CompanyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyTypeName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CompanyType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyTypeName = "Brand"
                        },
                        new
                        {
                            Id = 2,
                            CompanyTypeName = "Partner"
                        },
                        new
                        {
                            Id = 3,
                            CompanyTypeName = "Record"
                        },
                        new
                        {
                            Id = 4,
                            CompanyTypeName = "Project"
                        });
                });

            modelBuilder.Entity("LNDP_API.Models.Concert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArtistId")
                        .HasColumnType("integer");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Tickets")
                        .HasColumnType("text");

                    b.Property<string>("UrlLocation")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Concert");
                });

            modelBuilder.Entity("LNDP_API.Models.Festival", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Tickets")
                        .HasColumnType("text");

                    b.Property<string>("UrlLocation")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Festival");
                });

            modelBuilder.Entity("LNDP_API.Models.SocialNetwork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArtistId")
                        .HasColumnType("integer");

                    b.Property<string>("Instagram")
                        .HasColumnType("text");

                    b.Property<string>("Spotify")
                        .HasColumnType("text");

                    b.Property<string>("TikTok")
                        .HasColumnType("text");

                    b.Property<string>("Twitter")
                        .HasColumnType("text");

                    b.Property<string>("Youtube")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId")
                        .IsUnique();

                    b.ToTable("SocialNetwork");
                });

            modelBuilder.Entity("LNDP_API.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ArtistId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Song");
                });

            modelBuilder.Entity("LNDP_API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccesId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AccesId")
                        .IsUnique();

                    b.HasIndex("UserRoleId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccesId = 1,
                            Email = "Sanchez",
                            FirstName = "Sergio",
                            LastName = "Sanchez",
                            UserRoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            AccesId = 2,
                            Email = "Torres",
                            FirstName = "Jorge",
                            LastName = "Torres",
                            UserRoleId = 1
                        },
                        new
                        {
                            Id = 3,
                            AccesId = 3,
                            Email = "Tomas",
                            FirstName = "Tomas",
                            LastName = "De la Fuente",
                            UserRoleId = 1
                        },
                        new
                        {
                            Id = 4,
                            AccesId = 4,
                            Email = "Iglesias",
                            FirstName = "Alvaro",
                            LastName = "Iglesias",
                            UserRoleId = 2
                        });
                });

            modelBuilder.Entity("LNDP_API.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Role = "Visual"
                        },
                        new
                        {
                            Id = 3,
                            Role = "Crew"
                        });
                });

            modelBuilder.Entity("LNDP_API.Models.YoutubeVideo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("YoutubeVideo");
                });

            modelBuilder.Entity("LNDP_API.Models.Album", b =>
                {
                    b.HasOne("LNDP_API.Models.Artist", "Artist")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("LNDP_API.Models.Artist", b =>
                {
                    b.HasOne("LNDP_API.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LNDP_API.Models.ArtistFestivalAsoc", b =>
                {
                    b.HasOne("LNDP_API.Models.Artist", "Artist")
                        .WithMany("ArtistFestivalAsoc")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LNDP_API.Models.Festival", "Festival")
                        .WithMany("ArtistFestivalAsoc")
                        .HasForeignKey("FestivalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Festival");
                });

            modelBuilder.Entity("LNDP_API.Models.Company", b =>
                {
                    b.HasOne("LNDP_API.Models.CompanyType", "CompanyType")
                        .WithMany()
                        .HasForeignKey("CompanyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyType");
                });

            modelBuilder.Entity("LNDP_API.Models.Concert", b =>
                {
                    b.HasOne("LNDP_API.Models.Artist", "Artist")
                        .WithMany("Concerts")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("LNDP_API.Models.SocialNetwork", b =>
                {
                    b.HasOne("LNDP_API.Models.Artist", "Artist")
                        .WithOne("SocialNetwork")
                        .HasForeignKey("LNDP_API.Models.SocialNetwork", "ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("LNDP_API.Models.Song", b =>
                {
                    b.HasOne("LNDP_API.Models.Artist", "Artist")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("LNDP_API.Models.User", b =>
                {
                    b.HasOne("LNDP_API.Models.Acces", "Acces")
                        .WithOne("User")
                        .HasForeignKey("LNDP_API.Models.User", "AccesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LNDP_API.Models.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Acces");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("LNDP_API.Models.Acces", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("LNDP_API.Models.Artist", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("ArtistFestivalAsoc");

                    b.Navigation("Concerts");

                    b.Navigation("SocialNetwork");

                    b.Navigation("Songs");
                });

            modelBuilder.Entity("LNDP_API.Models.Festival", b =>
                {
                    b.Navigation("ArtistFestivalAsoc");
                });
#pragma warning restore 612, 618
        }
    }
}
