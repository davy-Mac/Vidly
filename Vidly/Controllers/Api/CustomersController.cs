using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context; // initializes the DbContext instance 

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET / api/customers
        public IHttpActionResult GetCustomers() // returns all the customers from the DB
        {
            var customerDtos = _context.Customers
                    .Include(c => c.MembershipType)
                    .ToList()
                    .Select(Mapper.Map<Customer, CustomerDto>); // maps out the object and selects it to return source "Customer" target "CustomerDto"

            return Ok(customerDtos);
        }

        // GET /api/customer/1
        public IHttpActionResult GetCustomer(int id) // returns only a single customer 
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST /api/customers
        //[HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto) // to create a customer remember to explicitly decorate the method with [HttpPost]
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT /api/customers/1 <= Example URL
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)  // to update a customer Requires [HttpPut]
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDto, customerInDb);


            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/customers/1  //Example URL
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id) // to Delete a customer requires [HttpDelete]
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
