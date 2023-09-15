using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.Cab.Booking.Api.Model
{
    public class Requests
    {
        [Key]
        public int RequestId { get; set; }

        [Required]
        [StringLength(80)]
        public string PickUpLocation { get; set; }

        [Required]
        [StringLength(80)]
        public string DropLocation { get; set; }

        [Required]
        public DateTime PickupTime { get; set; }

        [Required]
        [StringLength(10)]
        public string EmpId { get; set; }

        [Required]
        public int RequestStatusId { get; set; }

        [ForeignKey("EmpId")]
        public Employee? Employee { get; set; }

        [ForeignKey("RequestStatusId")]
        public RequestStatus? RequestStatus { get; set; }
    }


}