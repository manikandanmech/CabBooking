using Microsoft.AspNetCore.Mvc;
   using Microsoft.EntityFrameworkCore;
   using System.Collections.Generic;
   using System.Linq;
   using System.Threading.Tasks;
   using Employee.Cab.Booking.Api.Data;
   using Employee.Cab.Booking.Api.Model;

[Route("api/[controller]")]
   [ApiController]
   public class EmployeeDetailsController : ControllerBase
   {
       private readonly EmployeeCabBookingDBContext _context;

       public EmployeeDetailsController(EmployeeCabBookingDBContext context)
       {
           _context = context;
       }

       [HttpGet]
       public async Task<ActionResult<IEnumerable<Employee.Cab.Booking.Api.Model.Employee>>> GetEmployeeDetails()
       {
           return await _context.Employee.ToListAsync();
       }

       [HttpGet("{id}")]
       public async Task<ActionResult<Employee.Cab.Booking.Api.Model.Employee>> GetEmployeeDetail(string id)
       {
           var employeeDetail = await _context.Employee.FindAsync(id);

           if (employeeDetail == null)
           {
               return NotFound();
           }

           return employeeDetail;
       }
       [HttpPost]
       public async Task CreateEmployeeDetail(Employee.Cab.Booking.Api.Model.Employee employeeDetail)
       {
            _context.Add(employeeDetail);
            _context.SaveChanges();
       }


      


       [HttpPatch]
       [Route("UpdateEmployeeDetail/{id}")]
       public async Task<Employee.Cab.Booking.Api.Model.Employee> UpdateEmployeeDetail(Employee.Cab.Booking.Api.Model.Employee  objEmployeeDetail)
       {
        _context.Entry(objEmployeeDetail).State=EntityState.Modified;
        await _context.SaveChangesAsync();
        return objEmployeeDetail;
       }


       [HttpDelete("{id:int}")]
       public IActionResult Delete(string id)
       {
        if(id==null)
        {
            return BadRequest(ModelState);
        }
        var employeeDetail = _context.Employee.FirstOrDefault(x=>x.EmpId==id);
        _context.Remove(employeeDetail);
        _context.SaveChanges();
        return Ok();
       }
    }
    