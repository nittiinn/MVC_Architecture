using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewMVCApplication.Data.Models;
using NewMVCApplication.Entities;
using NewMVCApplication.Models;

namespace NewMVCApplication.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerDbContext _context;

        public CustomerController(CustomerDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("List");
            }
            return View(customer);
        }
    }
}
