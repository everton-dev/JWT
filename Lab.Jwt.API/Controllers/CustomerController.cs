using Lab.Jwt.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Lab.Jwt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        [HttpGet]
        [Route("List")]
        [Authorize]
        public IActionResult List()
        {
            var customers = new List<Customer> 
            {
                new Customer(1, "Everton", "everton@jwt-test.com"),
                new Customer(2, "John", "john@jwt-test.com"),
                new Customer(3, "Marry", "marry@jwt-test.com")
            };

            return new ObjectResult(customers);
        }

        [HttpGet]
        [Route("ListDev")]
        [Authorize(Roles = "developer")]
        public IActionResult ListDeveloper()
        {
            var customers = new List<Customer>
            {
                new Customer(1, "Everton", "everton@jwt-test.com"),
                new Customer(2, "John", "john@jwt-test.com"),
                new Customer(3, "Marry", "marry@jwt-test.com"),
                new Customer(1, "Developer", "developer@jwt-test.com")
            };

            return new ObjectResult(customers);
        }

        [HttpGet]
        [Route("ListAdmin")]
        [Authorize(Roles = "administrator")]
        public IActionResult ListAdministrator()
        {
            var customers = new List<Customer>
            {
                new Customer(1, "Everton", "everton@jwt-test.com"),
                new Customer(2, "John", "john@jwt-test.com"),
                new Customer(3, "Marry", "marry@jwt-test.com"),
                new Customer(1, "Administrator", "administrator@jwt-test.com")
            };

            return new ObjectResult(customers);
        }
    }
}