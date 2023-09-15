using Microsoft.AspNetCore.Mvc;
   using Microsoft.EntityFrameworkCore;
   using System.Collections.Generic;
   using System.Linq;
   using System.Threading.Tasks;
   using Employee.Cab.Booking.Api.Data;
   using Employee.Cab.Booking.Api.Model;

   [Route("api/[controller]")]
   [ApiController]
   public class DriverDetailsController : ControllerBase
   {
       private readonly EmployeeCabBookingDBContext _context;

       public DriverDetailsController(EmployeeCabBookingDBContext context)
       {
           _context = context;
       }

       [HttpGet]
       public async Task<ActionResult<IEnumerable<Driver>>> GetDriverDetailsControlleer()
       {
           return await _context.Driver.ToListAsync();
       }

       [HttpGet("{id}")]
       public async Task<ActionResult<Driver>>GetCabDetail(string id)
       {
           var driverDetail = await _context.Driver.FindAsync(id);

           if (driverDetail == null)
           {
               return NotFound();
           }

           return driverDetail;
       }
       [HttpPost]
       public async Task CreateDriverDetail(Driver driverDetail)
       {
            _context.Add(driverDetail);
            _context.SaveChanges();
       }
   }