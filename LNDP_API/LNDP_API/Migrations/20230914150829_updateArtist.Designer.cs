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
    [Migration("20230914150829_updateArtist")]
    partial class updateArtist
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CrewId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<int?>("PhotoId")
                        .HasColumnType("integer");

                    b.Property<string>("RecruitmentEmail")
                        .HasColumnType("text");

                    b.Property<int?>("SocialNetworkId")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CrewId")
                        .IsUnique();

                    b.HasIndex("PhotoId");

                    b.HasIndex("SocialNetworkId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("LNDP_API.Models.Crew", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArtistId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Dj")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("LightingTechnician")
                        .HasColumnType("text");

                    b.Property<string>("RoadManager")
                        .HasColumnType("text");

                    b.Property<string>("SoundTechnician")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Crew");
                });

            modelBuilder.Entity("LNDP_API.Models.Dosier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Dosier");
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

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("EventTypeId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

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

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EventName")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("EventType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(2023, 9, 14, 15, 8, 29, 593, DateTimeKind.Utc).AddTicks(5848),
                            EventName = "Festival",
                            IsActive = true
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(2023, 9, 14, 15, 8, 29, 593, DateTimeKind.Utc).AddTicks(5850),
                            EventName = "Concierto",
                            IsActive = true
                        });
                });

            modelBuilder.Entity("LNDP_API.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("DosierId")
                        .HasColumnType("integer");

                    b.Property<byte[]>("Imagen")
                        .HasColumnType("bytea");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DosierId");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("LNDP_API.Models.SocialNetwork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArtistId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Instagram")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Spotify")
                        .HasColumnType("text");

                    b.Property<string>("TikTok")
                        .HasColumnType("text");

                    b.Property<string>("Twitter")
                        .HasColumnType("text");

                    b.Property<string>("Youtube")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SocialNetwork");
                });

            modelBuilder.Entity("LNDP_API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArtistId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

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

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(2023, 9, 14, 15, 8, 29, 593, DateTimeKind.Utc).AddTicks(5970),
                            IsActive = true,
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(2023, 9, 14, 15, 8, 29, 593, DateTimeKind.Utc).AddTicks(5971),
                            IsActive = true,
                            Role = "Crew"
                        });
                });

            modelBuilder.Entity("LNDP_API.Models.Artist", b =>
                {
                    b.HasOne("LNDP_API.Models.Crew", "Crew")
                        .WithOne("Artist")
                        .HasForeignKey("LNDP_API.Models.Artist", "CrewId");

                    b.HasOne("LNDP_API.Models.Photo", "Photo")
                        .WithMany()
                        .HasForeignKey("PhotoId");

                    b.HasOne("LNDP_API.Models.SocialNetwork", "SocialNetwork")
                        .WithOne("Artist")
                        .HasForeignKey("LNDP_API.Models.Artist", "SocialNetworkId");

                    b.HasOne("LNDP_API.Models.User", "User")
                        .WithOne("Artist")
                        .HasForeignKey("LNDP_API.Models.Artist", "UserId");

                    b.Navigation("Crew");

                    b.Navigation("Photo");

                    b.Navigation("SocialNetwork");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LNDP_API.Models.Event", b =>
                {
                    b.HasOne("LNDP_API.Models.Artist", "Artist")
                        .WithMany("Events")
                        .HasForeignKey("ArtistId");

                    b.HasOne("LNDP_API.Models.EventType", "EventType")
                        .WithMany()
                        .HasForeignKey("EventTypeId");

                    b.Navigation("Artist");

                    b.Navigation("EventType");
                });

            modelBuilder.Entity("LNDP_API.Models.Photo", b =>
                {
                    b.HasOne("LNDP_API.Models.Dosier", null)
                        .WithMany("Photos")
                        .HasForeignKey("DosierId");
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
                    b.Navigation("Events");
                });

            modelBuilder.Entity("LNDP_API.Models.Crew", b =>
                {
                    b.Navigation("Artist");
                });

            modelBuilder.Entity("LNDP_API.Models.Dosier", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("LNDP_API.Models.SocialNetwork", b =>
                {
                    b.Navigation("Artist");
                });

            modelBuilder.Entity("LNDP_API.Models.User", b =>
                {
                    b.Navigation("Artist");
                });
#pragma warning restore 612, 618
        }
    }
}
