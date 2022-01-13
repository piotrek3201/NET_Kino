using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class ScreeningRoom
    {
        public int ScreeningRoomID { get; set; }
        [Required]
        public int RowCount { get; set; }
        public int ColumnCount { get; set; }
    }
}