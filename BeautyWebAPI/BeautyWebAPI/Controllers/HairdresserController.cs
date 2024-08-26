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
    public class HairdresserController : ControllerBase
    {
        // DbContextFactory injected by constructor / Dependency Injection 
        private IDbContextFactory<BeautyStudioDbContext> _dbContextFactory;

        // Constructor
        public HairdresserController(IDbContextFactory<BeautyStudioDbContext> dbContextFactory)
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


        [HttpGet(nameof(GetAllHairdresser))]
        public async Task<ActionResult<List<Hairdresser>>> GetAllHairdresser()
        {
            using (BeautyStudioDbContext context = await _dbContextFactory.CreateDbContextAsync())
            {
                var hairdressersFromDb = await context.Hairdressers.ToListAsync();
                return this.Ok(hairdressersFromDb);
            }

        }

        [HttpGet(nameof(GetHairdresserById) + "{id}")]

        public async Task<ActionResult<Hairdresser>> GetHairdresserById(int id)

        // var stehet für BeautyStudioDbContext
        {
            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                Hairdresser? hairdresserFromDb = await context.Hairdressers.FirstOrDefaultAsync(x => x.HairdresserId == id);

                return this.Ok(hairdresserFromDb);

            }


        }

        [HttpPost(nameof(AddHairdresser))]

        public async Task<ActionResult<List<Hairdresser>>> AddHairdresser(Hairdresser hairdresser)
        {

            //Task<ActionResult<List<Customer>>>
            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                await context.Hairdressers.AddAsync(hairdresser);// DbSet
                await context.SaveChangesAsync();


            }

            return this.Ok();
        }



        [HttpPut(nameof(UpdateHairdresser) + "{id}")]

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

        public async Task<ActionResult<Hairdresser>> UpdateHairdresser(int id, Hairdresser hairdresser)
        {
            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                context.Entry(hairdresser).State = EntityState.Modified;
                try
                {
                    await context.SaveChangesAsync();
                    return hairdresser;
                }
                catch (DbUpdateConcurrencyException)
                {
                    Customer? hairdresserToUpdate = await context.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);
                    if (hairdresserToUpdate == null)
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

        [HttpDelete(nameof(DeleteHairdresser) + "{id}")]
        //Alternative (?) [Route("{id}")]
        public async Task<ActionResult<List<Hairdresser>>> DeleteHairdresser(int id)
        {

            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                Hairdresser? hairdresserFromDb = await context.Hairdressers.FirstOrDefaultAsync(x => x.HairdresserId == id);
                if (hairdresserFromDb is null)
                {
                    return NotFound("Sorry ,but this customer doesn't exist.");
                }

                context.Hairdressers.Remove(hairdresserFromDb);
                await context.SaveChangesAsync();

                return Ok(await context.Hairdressers.ToListAsync());
            }

        }
    }
}

