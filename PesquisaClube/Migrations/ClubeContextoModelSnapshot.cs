﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PesquisaClube.Models;

namespace PesquisaClube.Migrations
{
    [DbContext(typeof(ClubeContexto))]
    partial class ClubeContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PesquisaClube.Models.Clube", b =>
                {
                    b.Property<int>("ClubeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClubeNome");

                    b.Property<int>("Qtde");

                    b.HasKey("ClubeId");

                    b.ToTable("Clube");
                });
#pragma warning restore 612, 618
        }
    }
}
