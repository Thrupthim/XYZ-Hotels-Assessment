using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XYZ_Hotels_Assessment.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public string? Floor { get; set; }
        public string? Availability { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal? price { get; set; }
        public Hotel? Hotels { get; set; }
    }
}
