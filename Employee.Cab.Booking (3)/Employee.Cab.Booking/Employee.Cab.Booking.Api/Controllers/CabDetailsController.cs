using Microsoft.AspNetCore.Mvc;
   using Microsoft.EntityFrameworkCore;
   using System.Collections.Generic;
   using System.Linq;
   using System.Threading.Tasks;
   using Employee.Cab.Booking.Api.Data;
   using Employee.Cab.Booking.Api.Model;

   [Route("api/[controller]")]
   [ApiController]
   public class CabDetailsController : ControllerBase
   {
       private readonly EmployeeCabBookingDBContext _context;

       public CabDetailsController(EmployeeCabBookingDBContext context)
       {
           _context = context;
       }

       [HttpGet]
       public async Task<ActionResult<IEnumerable<Cab>>> GetCabDetails()
       {
           return await _context.Cab.ToListAsync();
       }

       [HttpGet("{id}")]
       public async Task<ActionResult<Cab>> GetCabDetail(string id)
       {
           var cabDetail = await _context.Cab.FindAsync(id);

           if (cabDetail == null)
           {
               return NotFound();
           }

           return cabDetail;
       }
       [HttpPost]
       public async Task CreateCabDetail(Cab cabDetail)
       {
            _context.Add(cabDetail);
            _context.SaveChanges();
       }
   }