using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  
      [Route("[controller]")]
      [ApiController]
      public class CarController : Controller
      {
         public DataContext Context { get; set; }

         public CarController(DataContext context)
         {
            Context = context;
         }


         [HttpGet]
         [Route("GetCarList")]
         public async Task<ActionResult<List<Car>>> Get()
         {
            return Ok(await Context.Cars.ToListAsync());
         }

         [HttpPost]
         [Route("AddCar")]
         public async Task<ActionResult<List<Appointment>>> AddCar(Car car)
         {
            Context.Cars.Add(car);
            await Context.SaveChangesAsync();
            return Ok();
         }

      }
   

}

