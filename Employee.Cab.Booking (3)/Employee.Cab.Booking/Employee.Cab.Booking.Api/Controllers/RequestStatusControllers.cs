 using Microsoft.AspNetCore.Mvc;
   using Microsoft.EntityFrameworkCore;
   using System.Collections.Generic;
   using System.Linq;
   using System.Threading.Tasks;
   using Employee.Cab.Booking.Api.Data;
   using Employee.Cab.Booking.Api.Model;

[Route("api/[controller]")]
   [ApiController]
  public class RequestStatusController : ControllerBase
   {
       private readonly EmployeeCabBookingDBContext _context;

       public RequestStatusController(EmployeeCabBookingDBContext context)
       {
           _context = context;
       }

       [HttpGet]
       public async Task<ActionResult<IEnumerable<RequestStatus>>> RequestStatus()
       {
           return await _context.RequestStatus.ToListAsync();
       }

       [HttpGet("{id}")] 
       public async Task<ActionResult<RequestStatus>> GetRequestStatus(string id)
       {
           var RequestStatus = await _context.RequestStatus.FindAsync(id);

           if (RequestStatus == null)
           {
               return NotFound();
           }

           return RequestStatus;
       }
       [HttpPost]
       public async Task CreateRequestStatus(RequestStatus requestStatus)
       {
            _context.Add(requestStatus);
            _context.SaveChanges();
       }


       [HttpPatch]
       [Route("UpdateRequestStatus/{id}")]
       public async Task<RequestStatus> UpdateRequestSatus(RequestStatus  objrequestStatus)
       {
        _context.Entry(objrequestStatus).State=EntityState.Modified;
        await _context.SaveChangesAsync();
        return objrequestStatus;
       }


       [HttpDelete("{id:int}")]
       public IActionResult Delete(int id)
       {
        if(id==null)
        {
            return BadRequest(ModelState);
        }
        var RequestStatus = _context.RequestStatus.FirstOrDefault(x=>x.RequestStatusId==id);
        _context.Remove(RequestStatus);
        _context.SaveChanges();
        return Ok();
       }
    }