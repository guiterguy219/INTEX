using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INTEX.Controllers
{
    [Authorize(Roles = "seattlesales, master")]
    public class SalesPortalController : Controller
    {
        // GET: SalesPortal
        public ActionResult Index()
        {
            return View();
        }
    }
}