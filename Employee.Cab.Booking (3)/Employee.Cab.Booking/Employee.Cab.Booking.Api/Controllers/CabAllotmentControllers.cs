using Microsoft.AspNetCore.Mvc;
   using Microsoft.EntityFrameworkCore;
   using System.Collections.Generic;
   using System.Linq;
   using System.Threading.Tasks;
   using Employee.Cab.Booking.Api.Data;
   using Employee.Cab.Booking.Api.Model;

[Route("api/[controller]")]
   [ApiController]
  public class CabAllotmentController : ControllerBase
   {
       private readonly EmployeeCabBookingDBContext _context;

       public CabAllotmentController(EmployeeCabBookingDBContext context)
       {
           _context = context;
       }

       [HttpGet]
       public async Task<ActionResult<IEnumerable<CabAllotment>>> CabAllotment()
       {
           return await _context.CabAllotments.ToListAsync();
       }

       [HttpGet("{id}")] 
       public async Task<ActionResult<CabAllotment>> GetCabAllotment(string id)
       {
           var CabAllotments = await _context.CabAllotments.FindAsync(id);

           if (CabAllotments == null)
           {
               return NotFound();
           }

           return CabAllotments;
       }
       [HttpPost]
       public async Task CreateCabAllotment(CabAllotment cabAllotment)
       {
            _context.Add(cabAllotment);
            _context.SaveChanges();
       }


       [HttpPatch]
       [Route("UpdateCabAllotment/{id}")]
       public async Task<CabAllotment> UpdateCabAllotment(CabAllotment  objcabAllotment)
       {
        _context.Entry(objcabAllotment).State=EntityState.Modified;
        await _context.SaveChangesAsync();
        return objcabAllotment;
       }


       [HttpDelete("{id:int}")]
       public IActionResult Delete(int id)
       {
        if(id==null)
        {
            return BadRequest(ModelState);
        }
        var cabAllotment = _context.CabAllotments.FirstOrDefault(x=>x.CabAllotmentId==id);
        _context.Remove(cabAllotment);
        _context.SaveChanges();
        return Ok();
       }
    }