﻿// <auto-generated />
using System;
using ExchangeRate.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExchangeRate.Infrastructure.Migrations
{
    [DbContext(typeof(ExchangeRateDbContext))]
    partial class ExchangeRateDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExchangeRateEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BrojTecajnice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "broj_tecajnice");

                    b.Property<decimal>("BuyRate")
                        .HasColumnType("decimal(18, 4)")
                        .HasAnnotation("Relational:JsonPropertyName", "kupovni_tecaj");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "valuta");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasAnnotation("Relational:JsonPropertyName", "datum_primjene");

                    b.Property<string>("Drzava")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "drzava");

                    b.Property<string>("DrzavaIso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "drzava_iso");

                    b.Property<decimal>("MidRate")
                        .HasColumnType("decimal(18, 4)")
                        .HasAnnotation("Relational:JsonPropertyName", "srednji_tecaj");

                    b.Property<decimal>("SellRate")
                        .HasColumnType("decimal(18, 4)")
                        .HasAnnotation("Relational:JsonPropertyName", "prodajni_tecaj");

                    b.Property<string>("SifraValute")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "sifra_valute");

                    b.HasKey("Id");

                    b.ToTable("ExchangeRate");
                });
#pragma warning restore 612, 618
        }
    }
}
