using System.ComponentModel.DataAnnotations;

namespace Employee.Cab.Booking.Api.Model
{
    public class RequestStatus
    {
        [Key]
        public int RequestStatusId { get; set; }

        [Required]
        [StringLength(10)]
        public string StatusName { get; set; }
    }
}