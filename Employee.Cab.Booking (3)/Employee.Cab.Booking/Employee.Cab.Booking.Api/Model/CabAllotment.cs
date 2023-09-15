
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.Cab.Booking.Api.Model
{
  
    public class CabAllotment
    {
        [Key]
        public int CabAllotmentId { get; set; }

        [Required]
        public int RequestId { get; set; }

        [Required]
        public int CabId { get; set; }

        [ForeignKey("CabId")]
        public Cab CabDetail { get; set; }

        [ForeignKey("RequestId")]
        public Requests? Request { get; set; }
    }
}