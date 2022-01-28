using CoreBusiness;
using Microsoft.EntityFrameworkCore;

namespace Plugins.DataStore.SQL
{
    public class CinemaContext : DbContext
    {
        public CinemaContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ScreeningRoom> ScreeningRooms { get; set; }
        public DbSet<Showing> Showings { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Showings)
                .WithOne(s => s.Movie)
                .HasForeignKey(s => s.MovieId);

            modelBuilder.Entity<Showing>()
                .HasMany(s => s.Reservations)
                .WithOne(r => r.Showing)
                .HasForeignKey(r => r.ShowingId);

            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.Reservations)
                .WithOne(r => r.Ticket)
                .HasForeignKey(r => r.TicketId);

            modelBuilder.Entity<ScreeningRoom>()
                .HasMany(scr => scr.Showings)
                .WithOne(sh => sh.ScreeningRoom)
                .HasForeignKey(sh => sh.ScreeningRoomId);

            modelBuilder.Entity<Movie>().HasData(
                    new Movie()
                    {
                        MovieId = 1,
                        Title = "Matrix Zmartwychwstania",
                        Description = "Podążaj za Neo, który prowadzi zwyczajne życie w San Francisco, gdzie jego terapeuta przepisuje mu niebieskie pigułki. Jednak Morfeusz oferuje mu czerwoną pigułkę i ponownie otwiera jego umysł na świat Matrix.",
                        Length = 148,
                        Year = 2021,
                        AgeRestriction = 15,
                        ImageUrl = "https://fwcdn.pl/fpo/85/24/838524/7983979.6.jpg"
                    },
                    new Movie()
                    {
                        MovieId = 2,
                        Title = "Nie czas umierać",
                        Description = "Na prośbę swojego starego przyjaciela, Felixa Leitera z CIA, James Bond bierze udział w misji odbicia porwanego naukowca. Trop prowadzi do niebezpiecznego złoczyńcy.",
                        Length = 163,
                        Year = 2021,
                        AgeRestriction = 15,
                        ImageUrl = "https://fwcdn.pl/fpo/77/78/757778/7966011.6.jpg"
                    },
                    new Movie()
                    {
                        MovieId = 3,
                        Title = "Free Guy",
                        Description = "Pracownik banku odkrywa, że jest postacią niezależną w brutalnej przygodowej grze akcji.",
                        Length = 115,
                        Year = 2021,
                        AgeRestriction = 12,
                        ImageUrl = "https://fwcdn.pl/fpo/82/06/828206/7969398.6.jpg"
                    },
                    new Movie()
                    {
                        MovieId = 4,
                        Title = "Diuna",
                        Description = "Szlachetny ród Atrydów przybywa na Diunę, będącą jedynym źródłem najcenniejszej substancji we wszechświecie.",
                        Length = 155,
                        Year = 2021,
                        AgeRestriction = 13,
                        ImageUrl = "https://i.ebayimg.com/images/g/wUkAAOSwpOxhHUrd/s-l400.jpg"
                    },
                    new Movie()
                    {
                        MovieId = 5,
                        Title = "Spider-Man: Bez drogi do domu",
                        Description = "Kiedy cały świat dowiaduje się, że pod maską Spider Mana skrywa się Peter Parker, superbohater decyduje się zwrócić o pomoc do Doktora Strange'a.",
                        Length = 148,
                        Year = 2021,
                        AgeRestriction = 13,
                        ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQUFLWM-ZrmUUSs5kNkk6mdsST_eBVhcjwFCbLnbxt013rf7O9D"
                    },
                    new Movie()
                    {
                        MovieId = 6,
                        Title = "Eternals",
                        Description = "Opowieść o Eternals - przedwiecznej rasie nieśmiertelnych istot, które zamieszkiwały Ziemię i ukształtowały jej historię.",
                        Length = 157,
                        Year = 2021,
                        AgeRestriction = 13,
                        ImageUrl = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcTgjKTgI_15Qt9vy2Iuej0NniEIHAjFn_zqEqd12Ln-ep6jgO6e"
                    }
                );

            modelBuilder.Entity<ScreeningRoom>().HasData(
                    new ScreeningRoom() { ScreeningRoomId = 1, ScreeningRoomName = "1", ColumnCount = 10, RowCount = 5 },
                    new ScreeningRoom() { ScreeningRoomId = 2, ScreeningRoomName = "2", ColumnCount = 10, RowCount = 5 },
                    new ScreeningRoom() { ScreeningRoomId = 3, ScreeningRoomName = "3", ColumnCount = 15, RowCount = 7 }
                );

            modelBuilder.Entity<Showing>().HasData(
                    new Showing()
                    {
                        ShowingId = 1,
                        ScreeningRoomId = 1,
                        MovieId = 2,
                        Date = DateTime.Today,
                        TicketPrice = 20,
                        Dubbing = false
                    },
                    new Showing()
                    {
                        ShowingId = 2,
                        ScreeningRoomId = 1,
                        MovieId = 2,
                        Date = DateTime.Today.AddDays(1),
                        TicketPrice = 20,
                        Dubbing = false
                    },
                    new Showing()
                    {
                        ShowingId = 3,
                        ScreeningRoomId = 2,
                        MovieId = 1,
                        Date = DateTime.Today.AddDays(1),
                        TicketPrice = 20,
                        Dubbing = false
                    },
                    new Showing()
                    {
                        ShowingId = 4,
                        ScreeningRoomId = 3,
                        MovieId = 1,
                        Date = DateTime.Today.AddDays(2),
                        TicketPrice = 20,
                        Dubbing = false
                    }
                );

            modelBuilder.Entity<Ticket>().HasData(
                    new Ticket()
                    {
                        ClientMail = "dawid.leszczynski@student.wat.edu.pl",
                        TicketId = 1,
                        QRString = "QWERTYUIO"
                    },
                    new Ticket()
                    {
                        ClientMail = "piotr.kaluzinski@student.wat.edu.pl",
                        TicketId = 2,
                        QRString = "ASDFGHJKL"
                    }
                );

            modelBuilder.Entity<Reservation>().HasData(
                    new Reservation()
                    {
                        ReservationId = 1,
                        ShowingId = 1,
                        RowNumber = 4,
                        ColumnNumber = 6,
                        ReservationExpirationDate = DateTime.MaxValue,
                        TicketId = 1
                    },
                    new Reservation()
                    {
                        ReservationId = 2,
                        ShowingId = 1,
                        RowNumber = 4,
                        ColumnNumber = 7,
                        ReservationExpirationDate = DateTime.MaxValue,
                        TicketId = 1
                    },
                    new Reservation()
                    {
                        ReservationId = 3,
                        ShowingId = 1,
                        RowNumber = 3,
                        ColumnNumber = 2,
                        ReservationExpirationDate = DateTime.Now.AddMinutes(5),
                        TicketId = 2
                    }
                );

            


        }
    }
}