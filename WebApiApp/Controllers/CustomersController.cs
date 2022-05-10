﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly CustomerContext context;

        public CustomersController(CustomerContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAll()
            => await context.Customers.ToArrayAsync();

        [HttpPost]
        public async Task<Customer> Add([FromBody] Customer c)
        {
            context.Customers.Add(c);
            await context.SaveChangesAsync();
            return c;
        }
    }
}
