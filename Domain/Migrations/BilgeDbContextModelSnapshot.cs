﻿// <auto-generated />
using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Domain.Migrations
{
    [DbContext(typeof(BilgeDbContext))]
    partial class BilgeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Ders", b =>
                {
                    b.Property<int>("DersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DersAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DersId");

                    b.ToTable("Ders");
                });

            modelBuilder.Entity("Domain.Kullanici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LoginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RePassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasDefaultValue("user");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Kullanici");
                });

            modelBuilder.Entity("Domain.Ogrenci", b =>
                {
                    b.Property<int>("OgrenciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CikisTarih")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DogumTarih")
                        .HasColumnType("datetime2");

                    b.Property<string>("EPosta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("GirisTarih")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gsm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyadi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TcNo")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("OgrenciId");

                    b.ToTable("Ogrenciler");
                });

            modelBuilder.Entity("Domain.OgrenciSiniflar", b =>
                {
                    b.Property<int>("OgrenciId")
                        .HasColumnType("int");

                    b.Property<int>("SiniflarId")
                        .HasColumnType("int");

                    b.HasKey("OgrenciId", "SiniflarId");

                    b.HasIndex("SiniflarId");

                    b.ToTable("OgrenciSiniflar");
                });

            modelBuilder.Entity("Domain.Ogretmen", b =>
                {
                    b.Property<int>("OgretmenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CikisTarih")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DogumTarih")
                        .HasColumnType("datetime2");

                    b.Property<string>("EPosta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("GirisTarih")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gsm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TcNo")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("OgretmenId");

                    b.ToTable("Ogretmenler");
                });

            modelBuilder.Entity("Domain.OgretmenDers", b =>
                {
                    b.Property<int>("DersId")
                        .HasColumnType("int");

                    b.Property<int>("OgretmenId")
                        .HasColumnType("int");

                    b.HasKey("DersId", "OgretmenId");

                    b.HasIndex("OgretmenId");

                    b.ToTable("OgretmenDers");
                });

            modelBuilder.Entity("Domain.Siniflar", b =>
                {
                    b.Property<int>("SiniflarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Kapasite")
                        .HasColumnType("int");

                    b.Property<string>("SinifAdi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SiniflarId");

                    b.ToTable("Siniflar");
                });

            modelBuilder.Entity("Domain.Veli", b =>
                {
                    b.Property<int>("VeliId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EPosta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gsm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TcNo")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("VeliId");

                    b.ToTable("Veli");
                });

            modelBuilder.Entity("Domain.OgrenciSiniflar", b =>
                {
                    b.HasOne("Domain.Ogrenci", "Ogrenci")
                        .WithMany("Siniflar")
                        .HasForeignKey("OgrenciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Siniflar", "Siniflar")
                        .WithMany("Ogrenci")
                        .HasForeignKey("SiniflarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ogrenci");

                    b.Navigation("Siniflar");
                });

            modelBuilder.Entity("Domain.OgretmenDers", b =>
                {
                    b.HasOne("Domain.Ogretmen", "Ogretmen")
                        .WithMany("Ders")
                        .HasForeignKey("DersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Ders", "Ders")
                        .WithMany("Ogretmen")
                        .HasForeignKey("OgretmenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ders");

                    b.Navigation("Ogretmen");
                });

            modelBuilder.Entity("Domain.Ders", b =>
                {
                    b.Navigation("Ogretmen");
                });

            modelBuilder.Entity("Domain.Ogrenci", b =>
                {
                    b.Navigation("Siniflar");
                });

            modelBuilder.Entity("Domain.Ogretmen", b =>
                {
                    b.Navigation("Ders");
                });

            modelBuilder.Entity("Domain.Siniflar", b =>
                {
                    b.Navigation("Ogrenci");
                });
#pragma warning restore 612, 618
        }
    }
}
