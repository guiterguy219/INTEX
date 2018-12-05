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
    }
}