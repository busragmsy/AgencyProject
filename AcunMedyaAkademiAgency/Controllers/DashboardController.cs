using AcunMedyaAkademiAgency.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaAkademiAgency.Controllers
{
    public class DashboardController : Controller
    {
        AgencyContext context = new AgencyContext();
        public ActionResult Index()
        {
            ViewBag.bildirimsayisi = context.Notifications.ToList().Count();
            ViewBag.projectsayisi = context.Projects.ToList().Count();
            int categorygrafik = context.Categories.Where(x => x.CategoryName == "Grafik Tasarım").Select(y => y.CategoryId).FirstOrDefault();
            ViewBag.grafikCount = context.Projects.Where(x => x.CategoryId == categorygrafik).Count();
            ViewBag.personelsayisi = context.Teams.ToList().Count();
            ViewBag.mesajsayisi = context.Messages.ToList().Count();
            ViewBag.servicesayisi = context.Services.ToList().Count();
            int branssayisi = context.Branches.Where(x => x.BranchName == "Software Developer").Select(y => y.BranchId).FirstOrDefault();
            ViewBag.bransCount = context.Teams.Where(x => x.BranchId == branssayisi).Count();
            ViewBag.adminsayisi = context.Admins.ToList().Count();
            
            return View();
        }
        public PartialViewResult StaffPartial()
        {
            var values = context.Teams.ToList();
            return PartialView(values);
        }
        public PartialViewResult WeatherPartial()
        {
            return PartialView();
        }
        public PartialViewResult BrowserPartial()
        {
            return PartialView();
        }
    }
}