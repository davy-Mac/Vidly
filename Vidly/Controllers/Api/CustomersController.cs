using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.Models;
using Vidly.Models.Dtos;

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
        public IEnumerable<CustomerDto> GetCustomers() // returns the customers from the DB
        {
            return _context.Customers.ToList()
                .Select(Mapper.Map<Customer, CustomerDto>); // maps out the object and selects it to return source "Customer" target "CustomerDto"
        }

        // GET /api/customer/1
        //[HttpGet]
        public CustomerDto GetCustomer(int id) // returns only a single customer 
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customer, CustomerDto>(customer);
        }

        // POST /api/customers
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto) // to create a customer remember to explicitly decorate the method with [HttpPost]
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return customerDto;
        }

        // PUT /api/customers/1  //Example URL
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)  // to update a customer Requires [HttpPut]
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDb);


            _context.SaveChanges();
        }

        // DELETE api/customers/1  //Example URL
        [HttpDelete]
        public void DeleteCustomer(int id) // to Delete a customer requires [HttpDelete]
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
