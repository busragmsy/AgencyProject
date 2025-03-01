using AcunMedyaAkademiAgency.Context;
using AcunMedyaAkademiAgency.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AcunMedyaAkademiAgency.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        AgencyContext context = new AgencyContext();
        public ActionResult AdminLogin()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var result = context.Admins.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);
            if (result != null)
            {
                FormsAuthentication.SetAuthCookie(admin.Username, true);
                Session["username"] = result.Username;
                return RedirectToAction("Index", "Dashboard");
            }

            return View();
        }
        [HttpGet]
        public ActionResult AdminLogout()
        {
            Session["username"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("AdminLogin", "Login");
        }

    }
}