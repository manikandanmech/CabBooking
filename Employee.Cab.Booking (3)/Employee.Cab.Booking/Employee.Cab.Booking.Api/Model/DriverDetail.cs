using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.Cab.Booking.Api.Model
{
    public class Driver
    {
        [Key]
        public int DriverId { get; set; }

        [Required]
        [StringLength(50)]
        public string DriverName { get; set; }

        [Required]
        [StringLength(20)]
        public string ContactNo { get; set; }

        [Required]
        [StringLength(20)]
        public string LicenseNo { get; set; }

        [Required]
        public int CabId { get; set; }

        [ForeignKey("CabId")]
        public  Cab? CabDetail { get; set; }
    }
}