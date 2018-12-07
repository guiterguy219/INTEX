using INTEX.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace INTEX.Controllers
{
    [Authorize(Roles = "master")]
    [RequireHttps]
    public class MasterController : AccountController
    {
        // GET: Master
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
            //ViewBag.Roles = new SelectList(appdb.Roles, "Name", "Name");
            ViewBag.Roles = new SelectList(RoleManager.Roles.ToList(), "Name", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateUser(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    UserManager.AddToRole(user.Id, model.Role);

                    return RedirectToAction("Index", "Master");
                }
                AddErrors(result);
            }
            ViewBag.Roles = new SelectList(RoleManager.Roles.ToList(), "Name", "Name");
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateRole(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                if (!RoleManager.RoleExists(model.RoleName.ToLower()))
                {
                    await RoleManager.CreateAsync(new IdentityRole(model.RoleName.ToLower()));
                    return RedirectToAction("CreateUser");
                }
                ModelState.AddModelError("RoleModel", "That role name already exists.");
            }
            return View(model);
        }
    }
}