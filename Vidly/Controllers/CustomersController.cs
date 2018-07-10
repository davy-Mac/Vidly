using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context; //instance of ApplicationDbContext


        public CustomersController() // initializing the context object
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing) // overrides the Dispose method of the base controller class
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)

                return HttpNotFound();

            return View(customer);
        }
    }
}
