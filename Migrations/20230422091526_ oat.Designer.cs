﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using what_u_gonna_eat.Data;

#nullable disable

namespace what_u_gonna_eat.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230422091526_ oat")]
    partial class oat
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("what_u_gonna_eat.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DeliverPostId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeliverPostId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("what_u_gonna_eat.Models.DeliverPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DurationInMinutes")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Restaurant")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DeliverPost");
                });

            modelBuilder.Entity("what_u_gonna_eat.Models.EaterPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BenefactorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Menu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Restaurant")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TimeOut")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("accountId")
                        .HasColumnType("int");

                    b.Property<bool>("isClosed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("accountId");

                    b.ToTable("EaterPosts");
                });

            modelBuilder.Entity("what_u_gonna_eat.Models.Account", b =>
                {
                    b.HasOne("what_u_gonna_eat.Models.DeliverPost", null)
                        .WithMany("Participants")
                        .HasForeignKey("DeliverPostId");
                });

            modelBuilder.Entity("what_u_gonna_eat.Models.EaterPost", b =>
                {
                    b.HasOne("what_u_gonna_eat.Models.Account", "account")
                        .WithMany()
                        .HasForeignKey("accountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("account");
                });

            modelBuilder.Entity("what_u_gonna_eat.Models.DeliverPost", b =>
                {
                    b.Navigation("Participants");
                });
#pragma warning restore 612, 618
        }
    }
}
