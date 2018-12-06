using INTEX.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace INTEX.Controllers
{
    [RequireHttps]
    [Authorize(Roles = "customer, master")]
    public class CustomerPortalController : AccountController
    {
        // GET: CustomerPortal
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("CustomerPortal/Create/{id}")]
        public async Task<ActionResult> Create(string id)
        {
            ApplicationUser user = await UserManager.FindByIdAsync(id);
            ViewBag.User = user;
            ViewBag.States = new SelectList(db.State, "ID", "Abbreviation");
            Customer customer = new Customer();
            customer.CustEmail = user.Email;
            customer.UserID = user.Id;
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("CustomerPortal/Create/{id}")]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customer.Add(customer);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(customer);
        }

        public ActionResult newOrder()
        {
            return View();
        }

        public ActionResult newCompound()
        {
            return View();
        }

        public ActionResult newSample()
        {
            return View();
        }

        public ActionResult newQuote()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult newQuote(string quote)
        {
            //TODO: Finish HTTP Post Method
            return View("Index","Home");
        }

    }
}