using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class ScreeningRoom
    {
        [Required]
        public int ScreeningRoomId { get; set; }
        [Required]
        public string ScreeningRoomName { get; set;}
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Value out of range")]
        public int RowCount { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Value out of range")]
        public int ColumnCount { get; set; }

        //navigation property for ef core
        public List<Showing> Showings { get; set; }
    }
}