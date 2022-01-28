﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Plugins.DataStore.SQL;

#nullable disable

namespace Plugins.DataStore.SQL.Migrations
{
    [DbContext(typeof(CinemaContext))]
    partial class CinemaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CoreBusiness.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"), 1L, 1);

                    b.Property<int>("AgeRestriction")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            AgeRestriction = 15,
                            Description = "Podążaj za Neo, który prowadzi zwyczajne życie w San Francisco, gdzie jego terapeuta przepisuje mu niebieskie pigułki. Jednak Morfeusz oferuje mu czerwoną pigułkę i ponownie otwiera jego umysł na świat Matrix.",
                            ImageUrl = "https://fwcdn.pl/fpo/85/24/838524/7983979.6.jpg",
                            Length = 148,
                            Title = "Matrix Zmartwychwstania",
                            Year = 2021
                        },
                        new
                        {
                            MovieId = 2,
                            AgeRestriction = 15,
                            Description = "Na prośbę swojego starego przyjaciela, Felixa Leitera z CIA, James Bond bierze udział w misji odbicia porwanego naukowca. Trop prowadzi do niebezpiecznego złoczyńcy.",
                            ImageUrl = "https://fwcdn.pl/fpo/77/78/757778/7966011.6.jpg",
                            Length = 163,
                            Title = "Nie czas umierać",
                            Year = 2021
                        },
                        new
                        {
                            MovieId = 3,
                            AgeRestriction = 12,
                            Description = "Pracownik banku odkrywa, że jest postacią niezależną w brutalnej przygodowej grze akcji.",
                            ImageUrl = "https://fwcdn.pl/fpo/82/06/828206/7969398.6.jpg",
                            Length = 115,
                            Title = "Free Guy",
                            Year = 2021
                        },
                        new
                        {
                            MovieId = 4,
                            AgeRestriction = 13,
                            Description = "Szlachetny ród Atrydów przybywa na Diunę, będącą jedynym źródłem najcenniejszej substancji we wszechświecie.",
                            ImageUrl = "https://i.ebayimg.com/images/g/wUkAAOSwpOxhHUrd/s-l400.jpg",
                            Length = 155,
                            Title = "Diuna",
                            Year = 2021
                        },
                        new
                        {
                            MovieId = 5,
                            AgeRestriction = 13,
                            Description = "Kiedy cały świat dowiaduje się, że pod maską Spider Mana skrywa się Peter Parker, superbohater decyduje się zwrócić o pomoc do Doktora Strange'a.",
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQUFLWM-ZrmUUSs5kNkk6mdsST_eBVhcjwFCbLnbxt013rf7O9D",
                            Length = 148,
                            Title = "Spider-Man: Bez drogi do domu",
                            Year = 2021
                        },
                        new
                        {
                            MovieId = 6,
                            AgeRestriction = 13,
                            Description = "Opowieść o Eternals - przedwiecznej rasie nieśmiertelnych istot, które zamieszkiwały Ziemię i ukształtowały jej historię.",
                            ImageUrl = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcTgjKTgI_15Qt9vy2Iuej0NniEIHAjFn_zqEqd12Ln-ep6jgO6e",
                            Length = 157,
                            Title = "Eternals",
                            Year = 2021
                        });
                });

            modelBuilder.Entity("CoreBusiness.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"), 1L, 1);

                    b.Property<string>("ClientMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ColumnNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RowNumber")
                        .HasColumnType("int");

                    b.Property<int>("ShowingId")
                        .HasColumnType("int");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.HasIndex("ShowingId");

                    b.HasIndex("TicketId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            ReservationId = 1,
                            ClientMail = "",
                            ColumnNumber = 6,
                            ReservationExpirationDate = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999),
                            RowNumber = 4,
                            ShowingId = 1,
                            TicketId = 0
                        },
                        new
                        {
                            ReservationId = 2,
                            ClientMail = "",
                            ColumnNumber = 7,
                            ReservationExpirationDate = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999),
                            RowNumber = 4,
                            ShowingId = 1,
                            TicketId = 0
                        },
                        new
                        {
                            ReservationId = 3,
                            ClientMail = "",
                            ColumnNumber = 2,
                            ReservationExpirationDate = new DateTime(2022, 1, 28, 20, 45, 17, 794, DateTimeKind.Local).AddTicks(4279),
                            RowNumber = 3,
                            ShowingId = 1,
                            TicketId = 0
                        });
                });

            modelBuilder.Entity("CoreBusiness.ScreeningRoom", b =>
                {
                    b.Property<int>("ScreeningRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScreeningRoomId"), 1L, 1);

                    b.Property<int>("ColumnCount")
                        .HasColumnType("int");

                    b.Property<int>("RowCount")
                        .HasColumnType("int");

                    b.Property<string>("ScreeningRoomName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ScreeningRoomId");

                    b.ToTable("ScreeningRooms");

                    b.HasData(
                        new
                        {
                            ScreeningRoomId = 1,
                            ColumnCount = 10,
                            RowCount = 5,
                            ScreeningRoomName = "1"
                        },
                        new
                        {
                            ScreeningRoomId = 2,
                            ColumnCount = 10,
                            RowCount = 5,
                            ScreeningRoomName = "2"
                        },
                        new
                        {
                            ScreeningRoomId = 3,
                            ColumnCount = 15,
                            RowCount = 7,
                            ScreeningRoomName = "3"
                        });
                });

            modelBuilder.Entity("CoreBusiness.Showing", b =>
                {
                    b.Property<int>("ShowingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShowingId"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Dubbing")
                        .HasColumnType("bit");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("ScreeningRoomId")
                        .HasColumnType("int");

                    b.Property<double>("TicketPrice")
                        .HasColumnType("float");

                    b.HasKey("ShowingId");

                    b.HasIndex("MovieId");

                    b.HasIndex("ScreeningRoomId");

                    b.ToTable("Showings");

                    b.HasData(
                        new
                        {
                            ShowingId = 1,
                            Date = new DateTime(2022, 1, 28, 0, 0, 0, 0, DateTimeKind.Local),
                            Dubbing = false,
                            MovieId = 2,
                            ScreeningRoomId = 1,
                            TicketPrice = 20.0
                        },
                        new
                        {
                            ShowingId = 2,
                            Date = new DateTime(2022, 1, 29, 0, 0, 0, 0, DateTimeKind.Local),
                            Dubbing = false,
                            MovieId = 2,
                            ScreeningRoomId = 1,
                            TicketPrice = 20.0
                        },
                        new
                        {
                            ShowingId = 3,
                            Date = new DateTime(2022, 1, 29, 0, 0, 0, 0, DateTimeKind.Local),
                            Dubbing = false,
                            MovieId = 1,
                            ScreeningRoomId = 2,
                            TicketPrice = 20.0
                        },
                        new
                        {
                            ShowingId = 4,
                            Date = new DateTime(2022, 1, 30, 0, 0, 0, 0, DateTimeKind.Local),
                            Dubbing = false,
                            MovieId = 1,
                            ScreeningRoomId = 3,
                            TicketPrice = 20.0
                        });
                });

            modelBuilder.Entity("CoreBusiness.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"), 1L, 1);

                    b.Property<string>("ClientMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("QRString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QRStringImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TicketId");

                    b.ToTable("Tickets");

                    b.HasData(
                        new
                        {
                            TicketId = 1,
                            ClientMail = "dawid.leszczynski@student.wat.edu.pl",
                            PurchaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            QRString = "QWERTYUIO",
                            QRStringImage = ""
                        });
                });

            modelBuilder.Entity("CoreBusiness.Reservation", b =>
                {
                    b.HasOne("CoreBusiness.Showing", "Showing")
                        .WithMany("Reservations")
                        .HasForeignKey("ShowingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoreBusiness.Ticket", "Ticket")
                        .WithMany("Reservations")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Showing");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("CoreBusiness.Showing", b =>
                {
                    b.HasOne("CoreBusiness.Movie", "Movie")
                        .WithMany("Showings")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoreBusiness.ScreeningRoom", "ScreeningRoom")
                        .WithMany("Showings")
                        .HasForeignKey("ScreeningRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("ScreeningRoom");
                });

            modelBuilder.Entity("CoreBusiness.Movie", b =>
                {
                    b.Navigation("Showings");
                });

            modelBuilder.Entity("CoreBusiness.ScreeningRoom", b =>
                {
                    b.Navigation("Showings");
                });

            modelBuilder.Entity("CoreBusiness.Showing", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("CoreBusiness.Ticket", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
