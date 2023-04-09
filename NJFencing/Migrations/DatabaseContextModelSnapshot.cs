﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NJFencing.Database;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NJFencing.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NJFencing.Models.Account", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("NJFencing.Models.DualMeet", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<bool>("Conference")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Team1Id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<short>("Team1Score")
                        .HasColumnType("smallint");

                    b.Property<short>("Team1Score1")
                        .HasColumnType("smallint");

                    b.Property<short>("Team1Score2")
                        .HasColumnType("smallint");

                    b.Property<short>("Team1Score3")
                        .HasColumnType("smallint");

                    b.Property<string>("Team2Id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<short>("Team2Score")
                        .HasColumnType("smallint");

                    b.Property<short>("Team2Score1")
                        .HasColumnType("smallint");

                    b.Property<short>("Team2Score2")
                        .HasColumnType("smallint");

                    b.Property<short>("Team2Score3")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("Team1Id");

                    b.HasIndex("Team2Id");

                    b.ToTable("DualMeets");
                });

            modelBuilder.Entity("NJFencing.Models.Fencer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("GradYear")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Fencers");
                });

            modelBuilder.Entity("NJFencing.Models.FencerRecord", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("FencerId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<short>("Losses")
                        .HasColumnType("smallint");

                    b.Property<string>("MeetId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Weapon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<short>("Wins")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("FencerId");

                    b.HasIndex("MeetId");

                    b.ToTable("FencerRecords");
                });

            modelBuilder.Entity("NJFencing.Models.Team", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Coach")
                        .HasColumnType("text");

                    b.Property<string>("Conference")
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Icon")
                        .HasColumnType("text");

                    b.Property<string>("Mascot")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("NJFencing.Models.DualMeet", b =>
                {
                    b.HasOne("NJFencing.Models.Team", "Team1")
                        .WithMany("HomeMeets")
                        .HasForeignKey("Team1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NJFencing.Models.Team", "Team2")
                        .WithMany("AwayMeets")
                        .HasForeignKey("Team2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team1");

                    b.Navigation("Team2");
                });

            modelBuilder.Entity("NJFencing.Models.FencerRecord", b =>
                {
                    b.HasOne("NJFencing.Models.Fencer", "Fencer")
                        .WithMany("Records")
                        .HasForeignKey("FencerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NJFencing.Models.DualMeet", "Meet")
                        .WithMany("Records")
                        .HasForeignKey("MeetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fencer");

                    b.Navigation("Meet");
                });

            modelBuilder.Entity("NJFencing.Models.DualMeet", b =>
                {
                    b.Navigation("Records");
                });

            modelBuilder.Entity("NJFencing.Models.Fencer", b =>
                {
                    b.Navigation("Records");
                });

            modelBuilder.Entity("NJFencing.Models.Team", b =>
                {
                    b.Navigation("AwayMeets");

                    b.Navigation("HomeMeets");
                });
#pragma warning restore 612, 618
        }
    }
}
