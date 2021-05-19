﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoccerX.Data;

namespace SoccerX.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210518221949_TournamentEntities")]
    partial class TournamentEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SoccerX.Data.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("SoccerX.Data.Entities.GroupDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GoalsAgainst")
                        .HasColumnType("int");

                    b.Property<int>("GoalsFor")
                        .HasColumnType("int");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("MatchesLost")
                        .HasColumnType("int");

                    b.Property<int>("MatchesPlayed")
                        .HasColumnType("int");

                    b.Property<int>("MatchesTied")
                        .HasColumnType("int");

                    b.Property<int>("MatchesWon")
                        .HasColumnType("int");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("TeamId");

                    b.ToTable("GroupDetails");
                });

            modelBuilder.Entity("SoccerX.Data.Entities.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("GoalsLocal")
                        .HasColumnType("int");

                    b.Property<int>("GoalsVisitor")
                        .HasColumnType("int");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("bit");

                    b.Property<int?>("LocalId")
                        .HasColumnType("int");

                    b.Property<int?>("VisitorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("LocalId");

                    b.HasIndex("VisitorId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("SoccerX.Data.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LogoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("SoccerX.Data.Entities.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LogoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("SoccerX.Data.Entities.Group", b =>
                {
                    b.HasOne("SoccerX.Data.Entities.Tournament", "Tournament")
                        .WithMany("Groups")
                        .HasForeignKey("TournamentId");

                    //b.Navigation("Tournament");
                });

            modelBuilder.Entity("SoccerX.Data.Entities.GroupDetail", b =>
                {
                    b.HasOne("SoccerX.Data.Entities.Group", "Group")
                        .WithMany("GroupDetails")
                        .HasForeignKey("GroupId");

                    b.HasOne("SoccerX.Data.Entities.Team", "Team")
                        .WithMany("GroupDetails")
                        .HasForeignKey("TeamId");

                    //b.Navigation("Group");

                    //b.Navigation("Team");
                });

            modelBuilder.Entity("SoccerX.Data.Entities.Match", b =>
                {
                    b.HasOne("SoccerX.Data.Entities.Group", "Group")
                        .WithMany("Matches")
                        .HasForeignKey("GroupId");

                    b.HasOne("SoccerX.Data.Entities.Team", "Local")
                        .WithMany()
                        .HasForeignKey("LocalId");

                    b.HasOne("SoccerX.Data.Entities.Team", "Visitor")
                        .WithMany()
                        .HasForeignKey("VisitorId");

                    //b.Navigation("Group");

                    //b.Navigation("Local");

                    //b.Navigation("Visitor");
                });

            modelBuilder.Entity("SoccerX.Data.Entities.Group", b =>
                {
                    //b.Navigation("GroupDetails");

                    //b.Navigation("Matches");
                });

            modelBuilder.Entity("SoccerX.Data.Entities.Team", b =>
                {
                    //b.Navigation("GroupDetails");
                });

            modelBuilder.Entity("SoccerX.Data.Entities.Tournament", b =>
                {
                    //b.Navigation("Groups");
                });
#pragma warning restore 612, 618
        }
    }
}