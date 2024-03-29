﻿// <auto-generated />
using System;
using LireEnLigne.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LireEnLigne.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LireEnLigne.Models.Auteur", b =>
                {
                    b.Property<int>("AuteurID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AuteurName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Resume")
                        .HasColumnType("longtext");

                    b.HasKey("AuteurID");

                    b.ToTable("Auteur");
                });

            modelBuilder.Entity("LireEnLigne.Models.Emprunt", b =>
                {
                    b.Property<int>("EmpruntID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateEmprunt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateRetourPrevue")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ExemplaireID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateRetourEffective")
                        .HasColumnType("datetime(6)");

                    b.HasKey("EmpruntID")
                        .HasAnnotation("MySql: ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.HasIndex("ExemplaireID");

                    b.HasIndex("UserID");

                    b.ToTable("Emprunt", (string)null);
                });

            modelBuilder.Entity("LireEnLigne.Models.Exemplaire", b =>
                {
                    b.Property<int>("ExemplaireID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Edition")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Langue")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("LivreID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ExemplaireID")
                        .HasAnnotation("MySql: ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.HasIndex("LivreID");

                    b.ToTable("Exemplaire", (string)null);
                });

            modelBuilder.Entity("LireEnLigne.Models.Livre", b =>
                {
                    b.Property<int>("LivreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AuteurID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatePublication")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("Image")
                        .HasColumnType("longblob");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("NbreExemplaire")
                        .HasColumnType("int");

                    b.Property<int>("NbrePages")
                        .HasColumnType("int");

                    b.Property<string>("Resume")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("LivreID")
                        .HasAnnotation("MySql: ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.HasIndex("AuteurID");

                    b.ToTable("Livre", (string)null);
                });

            modelBuilder.Entity("LireEnLigne.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAnnulation")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateDemande")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateReservation")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ExemplaireID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ReservationID")
                        .HasAnnotation("MySql: ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.HasIndex("ExemplaireID");

                    b.HasIndex("UserID");

                    b.ToTable("Reservation", (string)null);
                });

            modelBuilder.Entity("LireEnLigne.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NumeroTelephone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.HasKey("Id")
                        .HasAnnotation("MySql: ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("LireEnLigne.Models.Emprunt", b =>
                {
                    b.HasOne("LireEnLigne.Models.Exemplaire", "Exemplaire")
                        .WithMany("Emprunts")
                        .HasForeignKey("ExemplaireID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LireEnLigne.Models.User", "User")
                        .WithMany("Emprunts")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exemplaire");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LireEnLigne.Models.Exemplaire", b =>
                {
                    b.HasOne("LireEnLigne.Models.Livre", "Livre")
                        .WithMany("Exemplaires")
                        .HasForeignKey("LivreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Livre");
                });

            modelBuilder.Entity("LireEnLigne.Models.Livre", b =>
                {
                    b.HasOne("LireEnLigne.Models.Auteur", "Auteur")
                        .WithMany("Livres")
                        .HasForeignKey("AuteurID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auteur");
                });

            modelBuilder.Entity("LireEnLigne.Models.Reservation", b =>
                {
                    b.HasOne("LireEnLigne.Models.Exemplaire", "Exemplaire")
                        .WithMany("Reservations")
                        .HasForeignKey("ExemplaireID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LireEnLigne.Models.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exemplaire");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LireEnLigne.Models.Auteur", b =>
                {
                    b.Navigation("Livres");
                });

            modelBuilder.Entity("LireEnLigne.Models.Exemplaire", b =>
                {
                    b.Navigation("Emprunts");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("LireEnLigne.Models.Livre", b =>
                {
                    b.Navigation("Exemplaires");
                });

            modelBuilder.Entity("LireEnLigne.Models.User", b =>
                {
                    b.Navigation("Emprunts");

                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
