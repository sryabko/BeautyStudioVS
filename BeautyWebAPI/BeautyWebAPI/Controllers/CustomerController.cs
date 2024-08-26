using BeautyWebAPI.Data;
using BeautyWebAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq.Expressions;

namespace BeautyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // DbContextFactory injected by constructor / Dependency Injection 
        private IDbContextFactory<BeautyStudioDbContext> _dbContextFactory; 
        
        // Constructor
        public CustomerController(IDbContextFactory<BeautyStudioDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory; 
        }

        //private static List<Customer> customers = new List<Customer> {
        //        new Customer

        //        {   CustomerId = 1,
        //            Name = "Jens",
        //            FamilyName = "Pintat",

        //        },
        //        new Customer

        //        {   CustomerId = 2,
        //            Name = "Bob",
        //            FamilyName = "Segodnja",

        //        }
        //    };


        [HttpGet(nameof(GetAllCustomers))]
        public async Task <ActionResult<List<Customer>>> GetAllCustomers()
        { 
            using (BeautyStudioDbContext context = await _dbContextFactory.CreateDbContextAsync())
            {
              var customersFromDb=  await context.Customers.ToListAsync();
              return this.Ok(customersFromDb);
            }    
           
        }

        [HttpGet(nameof(GetCustomerById) + "{id}")]
        
        public async Task<ActionResult<Customer>> GetCustomerById(int id)

            // var stehet für BeautyStudioDbContext
        {
            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                Customer? customerFromDb = await context.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);

                return this.Ok(customerFromDb);
                
            }

           
        }

        [HttpPost(nameof(AddCustomer))]

        public async Task<ActionResult<List<Customer>>> AddCustomer(Customer customer)
        {

            //Task<ActionResult<List<Customer>>>
            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                await context.Customers.AddAsync(customer);// DbSet
                await context.SaveChangesAsync();
           
            
            }
            
            return this.Ok();
        }       

        

        [HttpPut(nameof(UpdateCustomer) + "{id}")]
        
         //public async Task<ActionResult<Customer>> UpdateCustomer(Customer customer)
         //{

         //   using (var context = await _dbContextFactory.CreateDbContextAsync())
         //   {
         //       Customer? customerToUpdate = await context.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);
         //       if (customerToUpdate is null)
         //       {
         //           return NotFound("Sorry ,but this customer doesn't exist.");
         //       }




         //   }

          public async Task<ActionResult<Customer>> UpdateCustomer(int id, Customer customer)
            {
                using (var context = await _dbContextFactory.CreateDbContextAsync())
                {
                    context.Entry(customer).State = EntityState.Modified;
                    try
                    {
                        await context.SaveChangesAsync();
                         return customer; 
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                    Customer? customerToUpdate = await context.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);
                    if (customerToUpdate == null)
                        {
                            return null;
                        }
                        throw;
                    }


            }


            //    var customer = customers.Find(x => x.CustomerId == id);
            //    if (customer is null)
            //        return NotFound("Sorry ,but this customer doesn't exist.");
            //    customer.Name = request.Name;
            //    customer.FamilyName = request.FamilyName;
            //    //customer.CustomerId = request.CustomerId;

            //    return Ok(customers);
        }

        [HttpDelete(nameof(DeleteCustomer) + "{id}")]
        //Alternative (?) [Route("{id}")]
        public async Task<ActionResult<List<Customer>>> DeleteCustomer(int id)
        {

            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                Customer? customerFromDb = await context.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);
                if (customerFromDb is null)
                {
                    return NotFound("Sorry ,but this customer doesn't exist.");
                }

                context.Customers.Remove(customerFromDb);
                await context.SaveChangesAsync();

                return Ok(await context.Customers.ToListAsync());
            }

        }
    }
}
