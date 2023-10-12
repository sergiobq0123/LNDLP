﻿// <auto-generated />
using System;
using LNDP_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LNDP_API.Migrations
{
    [DbContext(typeof(APIContext))]
    partial class APIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LNDP_API.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArtistId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("text");

                    b.Property<string>("WebUrl")
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

                    b.Property<string>("Photo")
                        .HasColumnType("text");

                    b.Property<string>("RecruitmentEmail")
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("LNDP_API.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("text");

                    b.Property<string>("WebUrl")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("LNDP_API.Models.Collaboration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("text");

                    b.Property<string>("WebUrl")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Collaboration");
                });

            modelBuilder.Entity("LNDP_API.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CompanyTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("text");

                    b.Property<string>("WebUrl")
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
                        });
                });

            modelBuilder.Entity("LNDP_API.Models.Crew", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArtistId")
                        .HasColumnType("integer");

                    b.Property<string>("Dj")
                        .HasColumnType("text");

                    b.Property<string>("LightingTechnician")
                        .HasColumnType("text");

                    b.Property<string>("RoadManager")
                        .HasColumnType("text");

                    b.Property<string>("SoundTechnician")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId")
                        .IsUnique();

                    b.ToTable("Crew");
                });

            modelBuilder.Entity("LNDP_API.Models.Dossier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Dossier");
                });

            modelBuilder.Entity("LNDP_API.Models.Event", b =>
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

                    b.Property<int?>("EventTypeId")
                        .HasColumnType("integer");

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

                    b.HasIndex("EventTypeId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("LNDP_API.Models.EventType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("EventName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("EventType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EventName = "Festival"
                        },
                        new
                        {
                            Id = 2,
                            EventName = "Concierto"
                        });
                });

            modelBuilder.Entity("LNDP_API.Models.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("text");

                    b.Property<string>("WebUrl")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Record");
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

                    b.Property<int?>("ArtistId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Url")
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

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("bytea");

                    b.Property<int?>("UserRoleId")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserRoleId");

                    b.ToTable("User");
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
                            Role = "Crew"
                        });
                });

            modelBuilder.Entity("LNDP_API.Models.Album", b =>
                {
                    b.HasOne("LNDP_API.Models.Artist", "Artist")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("LNDP_API.Models.Artist", b =>
                {
                    b.HasOne("LNDP_API.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LNDP_API.Models.Company", b =>
                {
                    b.HasOne("LNDP_API.Models.CompanyType", "CompanyType")
                        .WithMany()
                        .HasForeignKey("CompanyTypeId");

                    b.Navigation("CompanyType");
                });

            modelBuilder.Entity("LNDP_API.Models.Crew", b =>
                {
                    b.HasOne("LNDP_API.Models.Artist", "Artist")
                        .WithOne("Crew")
                        .HasForeignKey("LNDP_API.Models.Crew", "ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("LNDP_API.Models.Event", b =>
                {
                    b.HasOne("LNDP_API.Models.Artist", "Artist")
                        .WithMany("Events")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LNDP_API.Models.EventType", "EventType")
                        .WithMany()
                        .HasForeignKey("EventTypeId");

                    b.Navigation("Artist");

                    b.Navigation("EventType");
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
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("LNDP_API.Models.User", b =>
                {
                    b.HasOne("LNDP_API.Models.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("LNDP_API.Models.Artist", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("Crew");

                    b.Navigation("Events");

                    b.Navigation("SocialNetwork");

                    b.Navigation("Songs");
                });
#pragma warning restore 612, 618
        }
    }
}
