namespace Employee.Cab.Booking.Api.Model
{
    public class PendingApproval
    {
        public int RequestId { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeePhone { get; set; }
        public string PickUpLocation { get; set; }
        public string DropLocation { get; set; }
        public DateTime PickUpTime { get; set; }
        public string RequestStatus { get; set; }

    }
}