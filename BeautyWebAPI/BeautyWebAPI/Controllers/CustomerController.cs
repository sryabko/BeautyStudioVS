using BeautyWebAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace BeautyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private static List<Customer> customers = new List<Customer> {
                new Customer

                {   CustomerId = 1, 
                    Name = "Jens", 
                    FamilyName = "Pintat", 
                    Sessions = new List<Session>
                     {
                         new Session
                         {
                             SessionId = 3,
                             HairdresserId = 3,


                          }
                     },
                },
                new Customer

                {   CustomerId = 1002,
                    Name = "Bob",
                    FamilyName = "Segodnja",
                    Sessions = new List<Session>
                     {
                         new Session
                         {
                             SessionId = 1002,
                             HairdresserId = 1,


                          }
                     },
                }

            };


        [HttpGet]
        public async Task <ActionResult<List<Customer>>> GetAllCustomers()
        { 

            return Ok(customers);
        }

        [HttpGet("{id}")]
        //[Route("{id}")]
        public async Task<ActionResult<List<Customer>>> GetSingleCustomers(int id)
        {
            var customerSingle = customers.Find(x => x.Id == id);
            return Ok(customerSingle);
        }
    }
}
