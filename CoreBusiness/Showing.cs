using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class Showing
    {
        [Required]
        public int ShowingId { get; set; }
        [Required]
        public int ScreeningRoomId { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public double TicketPrice { get; set; }

        //navigation property for ef core
        public ScreeningRoom ScreeningRoom { get; set; }
        public Movie Movie { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}
