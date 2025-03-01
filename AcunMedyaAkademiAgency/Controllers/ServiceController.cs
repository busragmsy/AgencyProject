using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiAgency.Context;
using AcunMedyaAkademiAgency.Entities;

namespace AcunMedyaAkademiAgency.Controllers
{
    public class ServiceController : Controller
    {
        AgencyContext context = new AgencyContext();
        public ActionResult ServiceList(string searchText)
        {
            List<Service> values;
            if (searchText != null)
            {
                values = context.Services.Where(x => x.Title.Contains(searchText)).ToList();
                return View(values);
            }
            values = context.Services.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateService()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult CreateService(Service service)
        {
            context.Services.Add(service);
            context.SaveChanges();

            return RedirectToAction("ServiceList");
        }
        public ActionResult DeleteService(int id)
        {
            var value = context.Services.Find(id);
            context.Services.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ServiceList");
        }
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var value = context.Services.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateService(Service service)
        {
            var value = context.Services.Find(service.ServiceId);
            value.Title = service.Title;
            value.ImageUrl = service.ImageUrl;
            value.Description = service.Description;
            context.SaveChanges();

            return RedirectToAction("ServiceList");
        }
    }
}