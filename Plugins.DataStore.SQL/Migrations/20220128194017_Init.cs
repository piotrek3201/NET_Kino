using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plugins.DataStore.SQL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    AgeRestriction = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "ScreeningRooms",
                columns: table => new
                {
                    ScreeningRoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScreeningRoomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowCount = table.Column<int>(type: "int", nullable: false),
                    ColumnCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreeningRooms", x => x.ScreeningRoomId);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QRString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QRStringImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                });

            migrationBuilder.CreateTable(
                name: "Showings",
                columns: table => new
                {
                    ShowingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScreeningRoomId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TicketPrice = table.Column<double>(type: "float", nullable: false),
                    Dubbing = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Showings", x => x.ShowingId);
                    table.ForeignKey(
                        name: "FK_Showings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Showings_ScreeningRooms_ScreeningRoomId",
                        column: x => x.ScreeningRoomId,
                        principalTable: "ScreeningRooms",
                        principalColumn: "ScreeningRoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShowingId = table.Column<int>(type: "int", nullable: false),
                    RowNumber = table.Column<int>(type: "int", nullable: false),
                    ColumnNumber = table.Column<int>(type: "int", nullable: false),
                    ReservationExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_Showings_ShowingId",
                        column: x => x.ShowingId,
                        principalTable: "Showings",
                        principalColumn: "ShowingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "AgeRestriction", "Description", "ImageUrl", "Length", "Title", "Year" },
                values: new object[,]
                {
                    { 1, 15, "Podążaj za Neo, który prowadzi zwyczajne życie w San Francisco, gdzie jego terapeuta przepisuje mu niebieskie pigułki. Jednak Morfeusz oferuje mu czerwoną pigułkę i ponownie otwiera jego umysł na świat Matrix.", "https://fwcdn.pl/fpo/85/24/838524/7983979.6.jpg", 148, "Matrix Zmartwychwstania", 2021 },
                    { 2, 15, "Na prośbę swojego starego przyjaciela, Felixa Leitera z CIA, James Bond bierze udział w misji odbicia porwanego naukowca. Trop prowadzi do niebezpiecznego złoczyńcy.", "https://fwcdn.pl/fpo/77/78/757778/7966011.6.jpg", 163, "Nie czas umierać", 2021 },
                    { 3, 12, "Pracownik banku odkrywa, że jest postacią niezależną w brutalnej przygodowej grze akcji.", "https://fwcdn.pl/fpo/82/06/828206/7969398.6.jpg", 115, "Free Guy", 2021 },
                    { 4, 13, "Szlachetny ród Atrydów przybywa na Diunę, będącą jedynym źródłem najcenniejszej substancji we wszechświecie.", "https://i.ebayimg.com/images/g/wUkAAOSwpOxhHUrd/s-l400.jpg", 155, "Diuna", 2021 },
                    { 5, 13, "Kiedy cały świat dowiaduje się, że pod maską Spider Mana skrywa się Peter Parker, superbohater decyduje się zwrócić o pomoc do Doktora Strange'a.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQUFLWM-ZrmUUSs5kNkk6mdsST_eBVhcjwFCbLnbxt013rf7O9D", 148, "Spider-Man: Bez drogi do domu", 2021 },
                    { 6, 13, "Opowieść o Eternals - przedwiecznej rasie nieśmiertelnych istot, które zamieszkiwały Ziemię i ukształtowały jej historię.", "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcTgjKTgI_15Qt9vy2Iuej0NniEIHAjFn_zqEqd12Ln-ep6jgO6e", 157, "Eternals", 2021 }
                });

            migrationBuilder.InsertData(
                table: "ScreeningRooms",
                columns: new[] { "ScreeningRoomId", "ColumnCount", "RowCount", "ScreeningRoomName" },
                values: new object[,]
                {
                    { 1, 10, 5, "1" },
                    { 2, 10, 5, "2" },
                    { 3, 15, 7, "3" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "ClientMail", "PurchaseDate", "QRString", "QRStringImage" },
                values: new object[] { 1, "dawid.leszczynski@student.wat.edu.pl", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "QWERTYUIO", "" });

            migrationBuilder.InsertData(
                table: "Showings",
                columns: new[] { "ShowingId", "Date", "Dubbing", "MovieId", "ScreeningRoomId", "TicketPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 28, 0, 0, 0, 0, DateTimeKind.Local), false, 2, 1, 20.0 },
                    { 2, new DateTime(2022, 1, 29, 0, 0, 0, 0, DateTimeKind.Local), false, 2, 1, 20.0 },
                    { 3, new DateTime(2022, 1, 29, 0, 0, 0, 0, DateTimeKind.Local), false, 1, 2, 20.0 },
                    { 4, new DateTime(2022, 1, 30, 0, 0, 0, 0, DateTimeKind.Local), false, 1, 3, 20.0 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "ClientMail", "ColumnNumber", "ReservationExpirationDate", "RowNumber", "ShowingId", "TicketId" },
                values: new object[] { 1, "", 6, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), 4, 1, 0 });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "ClientMail", "ColumnNumber", "ReservationExpirationDate", "RowNumber", "ShowingId", "TicketId" },
                values: new object[] { 2, "", 7, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), 4, 1, 0 });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "ClientMail", "ColumnNumber", "ReservationExpirationDate", "RowNumber", "ShowingId", "TicketId" },
                values: new object[] { 3, "", 2, new DateTime(2022, 1, 28, 20, 45, 17, 794, DateTimeKind.Local).AddTicks(4279), 3, 1, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ShowingId",
                table: "Reservations",
                column: "ShowingId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TicketId",
                table: "Reservations",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Showings_MovieId",
                table: "Showings",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Showings_ScreeningRoomId",
                table: "Showings",
                column: "ScreeningRoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Showings");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "ScreeningRooms");
        }
    }
}
