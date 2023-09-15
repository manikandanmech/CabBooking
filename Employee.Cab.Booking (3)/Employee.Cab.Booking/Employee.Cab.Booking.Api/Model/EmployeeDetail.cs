using System.ComponentModel.DataAnnotations;

namespace Employee.Cab.Booking.Api.Model
{
    public class Employee
    {
        [Key]
        [StringLength(10)]
        public string EmpId { get; set; }

        [Required]
        [StringLength(50)]
        public string EmpName { get; set; }

        [StringLength(10)]
        public string ManagerId { get; set; }

        [Required]
        [StringLength(20)]
        public string ContactNo { get; set; }

        [Required]
        [StringLength(50)]
        public string EmailId { get; set; }

        public ICollection<Requests>? Requests { get; set; }

    }
}