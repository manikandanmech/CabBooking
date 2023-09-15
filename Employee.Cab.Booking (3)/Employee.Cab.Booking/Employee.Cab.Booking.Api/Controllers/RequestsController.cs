using Microsoft.AspNetCore.Mvc;
   using Microsoft.EntityFrameworkCore;
   using System.Collections.Generic;
   using System.Linq;
   using System.Threading.Tasks;
   using Employee.Cab.Booking.Api.Data;
   using Employee.Cab.Booking.Api.Model;

[Route("api/Requests")]
   [ApiController]
  public class RequestsController : ControllerBase
   {
       private readonly EmployeeCabBookingDBContext _context;

       public RequestsController(EmployeeCabBookingDBContext context)
       {
           _context = context;
       }

       [HttpGet]
       public async Task<ActionResult<IEnumerable<Requests>>> Requests()
       {
           var requests= await _context.Requests.ToListAsync();
           if (requests==null)
           {
            return new List<Requests>();
           }

           return requests;
       }

       [HttpGet("{id}")] 
       public async Task<ActionResult<Requests>> GetRequests(string id)
       {
           var Requests = await _context.Requests.FindAsync(id);

           if (Requests == null)
           {
               return NotFound();
           }

           return Requests;
       }
       [HttpPost]
       public async Task CreateRequests(Requests requests)
       {
            _context.Add(requests);
            _context.SaveChanges();
       }


        [HttpGet("byEmpId/{empId}")]
       public IActionResult GetRequestsByEmpId(string empId){
        var requests = _context.Requests.Where(r => r.EmpId == empId).ToList();
        if (requests == null || requests.Count == 0){
            return NotFound("No requests found for the specified EmpId."); 
            }
            return Ok(requests); }


       [HttpPatch]
       [Route("UpdateRequests/{id}")]
       public async Task<Requests> UpdateRequests(Requests objrequests)
       {
        _context.Entry(objrequests).State=EntityState.Modified;
        await _context.SaveChangesAsync();
        return objrequests;
       }


       [HttpDelete("{id:int}")]
       public IActionResult Delete(int id)
       {
        if(id==null)
        {
            return BadRequest(ModelState);
        }
        var cabAllotment = _context.Requests.FirstOrDefault(x=>x.RequestId==id);
        _context.Remove(cabAllotment);
        _context.SaveChanges();
        return Ok();
       }
    }