using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class Reservation
    {
        [Required]
        public int ReservationId { get; set; }

        [Required]
        public int ShowingId { get; set; }

        [Required] // clasically denoted by a letter, but in this case it's a number
        public int RowNumber { get; set; }

        [Required]
        public int ColumnNumber { get; set; }

        // when client chooses to buy a seat, reservation is made and expiration date is set to, i.e., +15 minutes
        // if payment is processed, expiration date is set to, i.e., +5 years
        // this means we can lock in seats during payment period and if payment fails, they will be unlocked
        public DateTime ReservationExpirationDate { get; set; }

        // foreign key pair for ticket
        public string ClientMail { get; set; } = string.Empty;
        public int TicketId { get; set; }

        //navigation property for ef core
        public Showing Showing { get; set; }
        public Ticket Ticket { get; set; }
    }
}
