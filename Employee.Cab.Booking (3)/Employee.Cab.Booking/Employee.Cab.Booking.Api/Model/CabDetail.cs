using System.ComponentModel.DataAnnotations;

namespace Employee.Cab.Booking.Api.Model
{
    public class Cab
    {
        [Key]
        public int CabId { get; set; }

        [Required]
        [StringLength(20)]
        public string CabNo { get; set; }

        [Required]
        public int Capacity { get; set; }

        // Navigation property for CabAllotments
        public ICollection<CabAllotment>? CabAllotments { get; set; }
        // Navigation property for Drivers
        public ICollection<Driver>? Drivers { get; set; }

    }
}