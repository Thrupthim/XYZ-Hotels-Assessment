using System.ComponentModel.DataAnnotations;

namespace XYZ_Hotels_Assessment.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }
        public string? HotelName { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public ICollection<Room>? Rooms { get; set; }
    }
}
