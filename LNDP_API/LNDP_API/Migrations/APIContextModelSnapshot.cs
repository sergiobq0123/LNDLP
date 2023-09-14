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

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("bytea");

                    b.Property<string>("RecruitmentEmail")
                        .HasColumnType("text");

                    b.HasKey("Id");

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

                    b.HasIndex("ArtistId")
                        .IsUnique();

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

                    b.Property<int?>("Photos")
                        .HasColumnType("integer");

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
                            CreationDate = new DateTime(2023, 9, 14, 19, 2, 50, 599, DateTimeKind.Utc).AddTicks(9364),
                            EventName = "Festival",
                            IsActive = true
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(2023, 9, 14, 19, 2, 50, 599, DateTimeKind.Utc).AddTicks(9366),
                            EventName = "Concierto",
                            IsActive = true
                        });
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

                    b.HasIndex("ArtistId")
                        .IsUnique();

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

                    b.HasIndex("ArtistId")
                        .IsUnique();

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
                            CreationDate = new DateTime(2023, 9, 14, 19, 2, 50, 599, DateTimeKind.Utc).AddTicks(9479),
                            IsActive = true,
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(2023, 9, 14, 19, 2, 50, 599, DateTimeKind.Utc).AddTicks(9480),
                            IsActive = true,
                            Role = "Crew"
                        });
                });

            modelBuilder.Entity("LNDP_API.Models.Crew", b =>
                {
                    b.HasOne("LNDP_API.Models.Artist", "Artist")
                        .WithOne("Crew")
                        .HasForeignKey("LNDP_API.Models.Crew", "ArtistId");

                    b.Navigation("Artist");
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

            modelBuilder.Entity("LNDP_API.Models.SocialNetwork", b =>
                {
                    b.HasOne("LNDP_API.Models.Artist", "Artist")
                        .WithOne("SocialNetwork")
                        .HasForeignKey("LNDP_API.Models.SocialNetwork", "ArtistId");

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("LNDP_API.Models.User", b =>
                {
                    b.HasOne("LNDP_API.Models.Artist", "Artist")
                        .WithOne("User")
                        .HasForeignKey("LNDP_API.Models.User", "ArtistId");

                    b.HasOne("LNDP_API.Models.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId");

                    b.Navigation("Artist");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("LNDP_API.Models.Artist", b =>
                {
                    b.Navigation("Crew");

                    b.Navigation("Events");

                    b.Navigation("SocialNetwork");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
