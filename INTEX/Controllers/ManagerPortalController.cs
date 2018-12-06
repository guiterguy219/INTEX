using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INTEX.Controllers
{
    [Authorize(Roles = "management, master")]
    public class ManagerPortalController : Controller
    {
        // GET: ManagerPortal
        public ActionResult Index()
        {
            return View();
        }

        //TODO: Add Sales Reports Functionality
        //TODO: Add Test Scheduling Functionality
        //TODO: Add View Results Functionality
    }
}