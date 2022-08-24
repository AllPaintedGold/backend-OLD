using Microsoft.AspNetCore.Mvc;

 

namespace API.Controllers
{
   [Route("[controller]")]
   [ApiController]
   public class CustomerController : Controller
   {
      public DataContext Context { get; set; }

      public CustomerController(DataContext context)
      {
         Context = context;
      }

      [HttpGet]
      [Route("GetCustomerList")]
      public async Task<ActionResult<List<Customer>>> Get()
      {
         return Ok(await Context.Customers.ToListAsync());
      }

      [HttpPost]
      [Route("AddCustomer")]
      public async Task<ActionResult<List<Customer>>> AddCustomer(Customer customer)
      {
         Context.Customers.Add(customer);
         await Context.SaveChangesAsync();
         return Ok(/*await Context.Customers.ToListAsync()*/);
      }

      [HttpGet]
      [Route("SearchCustomer")]
      public async Task<ActionResult<List<Customer>>> Get(string firstName, string lastName)
      {
         var customer = await Context.Customers.Where(x => x.FirstName == firstName && x.LastName == lastName).ToListAsync();
         if (customer == null)
            return BadRequest("Customer not found.");
         return Ok(customer);
      }

      [HttpGet]
      [Route("GetCustomer/{id}")]
      public async Task<ActionResult<Customer>> Get(int id)
      {
         var customer = await Context.Customers.FindAsync(id);
         if (customer == null)
            return BadRequest("Customer not found.");
         return Ok(customer);
      }

      [HttpPut]
      [Route("UpdateCustomer")]
      public async Task<ActionResult<List<Customer>>> UpdateCustomer(Customer request)
      {
         var dbCustomer = await Context.Customers.FindAsync(request.Id);
         if (dbCustomer == null)
            return BadRequest("Customer not found.");
         dbCustomer.FirstName = request.FirstName;
         dbCustomer.FirstName = request.LastName;
         dbCustomer.Country = request.Country;

         await Context.SaveChangesAsync();

         return Ok(await Context.Customers.ToListAsync());
      }

      [HttpDelete]
      [Route("DeleteCustomer")]
      public async Task<ActionResult<List<Customer>>> Delete(int id)
      {
         var dbCustomer = await Context.Customers.FindAsync(id);
         if (dbCustomer == null)
            return BadRequest("Customer not found.");

         Context.Customers.Remove(dbCustomer);
         await Context.SaveChangesAsync();

         return Ok(await Context.Customers.ToListAsync());
      }



   }
}
