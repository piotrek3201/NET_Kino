using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class Ticket
    {
        // ticket is identified by both mail and ticket id in pair
        [Required] 
        public string ClientMail { get; set; } = string.Empty;

        [Required]
        public int TicketId { get; set; }

        public string QRString { get; set; } = string.Empty;

        public string QRStringImage { get; set; } = string.Empty;

        public DateTime PurchaseDate { get; set; }

        //navigation property for ef core
        public List<Reservation> Reservations { get; set; }
    }
}
