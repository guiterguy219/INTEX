using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INTEX.Controllers
{
    [Authorize(Roles = "singaporelabtech, master")]
    public class LabPortalController : Controller
    {
        // GET: LabPortal
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult viewQuotes()
        {
            return View();
        }
        //TODO: Add Update Quote Status functionality
        //TODO: Add View Test Schedule
        //TODO: Add View Today's Orders
        //TODO: Add Update Order Status
        //TODO: Add Update Test Functionality
    }
}