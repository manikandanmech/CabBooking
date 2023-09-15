using Microsoft.AspNetCore.Mvc;
   using Microsoft.EntityFrameworkCore;
   using System.Collections.Generic;
   using System.Linq;
   using System.Threading.Tasks;
   using Employee.Cab.Booking.Api.Data;
   using Employee.Cab.Booking.Api.Model;

[Route("api/[controller]")]
   [ApiController]
   public class MangerController : ControllerBase
   {
       private readonly EmployeeCabBookingDBContext _context;

       public MangerController(EmployeeCabBookingDBContext context)
       {
           _context = context;
       }

       [HttpGet("{id}")]
       public async Task<bool> IsManager(string id)
       {
           var employeeDetail = _context.Employee.Where(x => x.ManagerId == id).Any();

           return employeeDetail;
       }

        [HttpGet("approvals/{id}")]
       public async Task<List<PendingApproval>> PendingApprovals(string id)
       {
            var query = from requests in _context.Requests 
                        join employee in _context.Employee on requests.EmpId equals employee.EmpId 
                        where employee.ManagerId == id
                        select new PendingApproval
                        {
                            RequestId = requests.RequestId,
                            EmployeeId = employee.EmpId,
                            EmployeeName = employee.EmpName,
                            EmployeeEmail = employee.EmailId,
                            EmployeePhone = employee.ContactNo,
                            PickUpLocation = requests.PickUpLocation,
                            PickUpTime = requests.PickupTime,
                            DropLocation = requests.DropLocation,
                            RequestStatus = "Pending"
                        };

            return query.ToList();
       }

       
    }
    