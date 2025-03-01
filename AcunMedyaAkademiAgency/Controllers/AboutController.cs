using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiAgency.Context;
using AcunMedyaAkademiAgency.Entities;


namespace AcunMedyaAkademiAgency.Controllers
{
    public class AboutController : Controller
    {
        AgencyContext context = new AgencyContext();
        public ActionResult AboutList(string searchText)
        {
            List<About> values;
            if (searchText != null)
            {
                values = context.Abouts.Where(x => x.Title.Contains(searchText)).ToList();
                return View(values);
            }
            values = context.Abouts.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateAbout()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateAbout(About about)
        {
            context.Abouts.Add(about);
            context.SaveChanges();

            return RedirectToAction("AboutList");
        }
        public ActionResult DeleteAbout(int id)
        {
            var value = context.Abouts.Find(id);
            context.Abouts.Remove(value);
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = context.Abouts.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var value = context.Abouts.Find(about.AboutId);
            value.Title = about.Title;
            value.ImageUrl = about.ImageUrl;
            value.Description = about.Description;
            value.Date = about.Date;
            context.SaveChanges();

            return RedirectToAction("AboutList");
        }
    }
}