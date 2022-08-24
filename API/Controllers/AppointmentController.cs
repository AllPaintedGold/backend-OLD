using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
   [Route("[controller]")]
   [ApiController]
   public class AppointmentController : Controller
   {
      public DataContext Context { get; set;  }

      public AppointmentController(DataContext context)
      {
         Context = context;
      }


      [HttpGet]
      [Route("GetAppointmentList")]
      public async Task<ActionResult<List<Appointment>>> Get()
      {
         return Ok(await Context.Appointments.ToListAsync());
      }

      [HttpPost]
      [Route("AddAppointment")]
      public async Task<ActionResult<List<Appointment>>> AddCustomer(Appointment appointment)
      {
         Context.Appointments.Add(appointment);
         await Context.SaveChangesAsync();
         return Ok();
      }

   }
}
