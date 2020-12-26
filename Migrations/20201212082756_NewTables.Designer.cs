﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using WebAPINetCore.ModelContexts;

namespace WebAPINetCore.Migrations
{
    [DbContext(typeof(AuthContext))]
    [Migration("20201212082756_NewTables")]
    partial class NewTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            modelBuilder.Entity("WebAPINetCore.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AcceptTerms")
                        .HasColumnType("NUMBER(1)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Email")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("FirstName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("LastName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime?>("PasswordReset")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("ResetToken")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime?>("ResetTokenExpires")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Title")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("VerificationToken")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime?>("Verified")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("WebAPINetCore.Entities.DMHuyen", b =>
                {
                    b.Property<string>("Ma")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<int>("Cap")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("MaTinh")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("NSD")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("NgayNhap")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Ten")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Ma");

                    b.ToTable("DMHuyen");
                });

            modelBuilder.Entity("WebAPINetCore.Entities.DMPhuongXa", b =>
                {
                    b.Property<string>("Ma")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<int>("Cap")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("MaHuyen")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("MaTinh")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("NSD")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("NgayNhap")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Ten")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Ma");

                    b.ToTable("DMPhuongXa");
                });

            modelBuilder.Entity("WebAPINetCore.Entities.DMTinh", b =>
                {
                    b.Property<string>("Ma")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<int>("Cap")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("NSD")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("NgayNhap")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Ten")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Ma");

                    b.ToTable("DMTinh");
                });

            modelBuilder.Entity("WebAPINetCore.Entities.Account", b =>
                {
                    b.OwnsMany("WebAPINetCore.Entities.RefreshToken", "RefreshTokens", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("NUMBER(10)")
                                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("AccountId")
                                .HasColumnType("NUMBER(10)");

                            b1.Property<string>("CreateByIp")
                                .HasColumnType("NVARCHAR2(2000)");

                            b1.Property<DateTime>("Created")
                                .HasColumnType("TIMESTAMP(7)");

                            b1.Property<DateTime>("Expires")
                                .HasColumnType("TIMESTAMP(7)");

                            b1.Property<string>("ReplaceByToken")
                                .HasColumnType("NVARCHAR2(2000)");

                            b1.Property<string>("RevokeByIp")
                                .HasColumnType("NVARCHAR2(2000)");

                            b1.Property<DateTime?>("Revoked")
                                .HasColumnType("TIMESTAMP(7)");

                            b1.Property<string>("Token")
                                .HasColumnType("NVARCHAR2(2000)");

                            b1.HasKey("Id");

                            b1.HasIndex("AccountId");

                            b1.ToTable("RefreshToken");

                            b1.WithOwner("Account")
                                .HasForeignKey("AccountId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
