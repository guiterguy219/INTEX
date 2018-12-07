using INTEX.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace INTEX.Controllers
{
    [RequireHttps]
    [Authorize(Roles = "customer, master")]
    public class CustomerPortalController : AccountController
    {
        // GET: CustomerPortal
        public async Task<ActionResult> Index()
        {
            ApplicationUser user = await UserManager.FindByNameAsync(SignInManager.AuthenticationManager.User.Identity.Name);
            List<Customer> customers = db.Customer.Where(c => c.UserID == user.Id).ToList();
            if(customers.Count > 0)
            {
                ViewBag.ProfileComplete = true;
            }
            else
            {
                ViewBag.ProfileComplete = false;
            }
            ViewBag.Profile = user;
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

        public async Task<ActionResult> newOrder()
        {
            ApplicationUser user = await UserManager.FindByNameAsync(SignInManager.AuthenticationManager.User.Identity.Name);
            List<Customer> customers = db.Customer.Where(c => c.UserID == user.Id).ToList();
            if (customers.Count > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Create", routeValues: new { id = user.Id });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult newOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                order.OrderDate = DateTime.Now;
                order.CustomerID = db.Customer.Where(c => c.CustEmail == User.Identity.Name).First().CustomerID;
                order.OrderStatus = "Requested";
                db.Order.Add(order);
                db.SaveChanges();

                return RedirectToAction("newCompound", routeValues: new { orderID = order.OrderID});
            }
            return View(order);
        }

        public ActionResult newCompound(int orderID)
        {
            Order order = db.Order.Find(orderID);
            List<Compound> compounds = new List<Compound>();
            for (int i = 0; i < order.numCompounds; i++){
                Compound compound = new Compound();
                compound.OrderID = orderID;
                compounds.Add(compound);
            }
            order.Compounds = compounds;

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult newCompound(Order order)
        {
            if (ModelState.IsValid)
            {
                foreach(Compound compound in order.Compounds)
                {
                    db.Compound.Add(compound);
                    db.SaveChanges();
                }

                return RedirectToAction("newSample", routeValues: new { orderID = order.OrderID });
            }

            return View(order);
        }

        public ActionResult newSample(int orderID)
        {
            Order order = db.Order.Find(orderID);
            foreach(Compound compound in order.Compounds)
            {
                List<Sample> samples = new List<Sample>();
                for (int i = 0; i < compound.numSamples; i++)
                {
                    Sample sample = new Sample();
                    sample.LTNumber = compound.LTNumber;
                    samples.Add(sample);
                }
            }
            return View(order);
        }

        public async Task<ActionResult> newQuote()
        {
            ApplicationUser user = await UserManager.FindByNameAsync(SignInManager.AuthenticationManager.User.Identity.Name);
            List<Customer> customers = db.Customer.Where(c => c.UserID == user.Id).ToList();
            if (customers.Count > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Create", routeValues: new { id = user.Id });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult newQuote(string quote)
        {
            //TODO: Finish HTTP Post Method
            return View("Index","Home");
        }

        public async Task<ActionResult> Account()
        {
            ApplicationUser user = await UserManager.FindByNameAsync(SignInManager.AuthenticationManager.User.Identity.Name);
            List<Customer> customers = db.Customer.Where(c => c.UserID == user.Id).ToList();
            if (customers.Count > 0)
            {
                ViewBag.States = new SelectList(db.State, "ID", "Abbreviation");
                return View(customers.First());
            }
            else
            {
                return RedirectToAction("Create", routeValues: new { id = user.Id });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Account(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("index");
            }

            return View(customer);
        }
    }
}