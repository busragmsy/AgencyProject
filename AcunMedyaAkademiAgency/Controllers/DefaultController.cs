using AcunMedyaAkademiAgency.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiAgency.Entities;
using AcunMedyaAkademiAgency.Migrations;


namespace AcunMedyaAkademiAgency.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        AgencyContext context = new AgencyContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult ProjectPartial()
        {
            var values = context.Projects.OrderByDescending(x => x.ProjectId).Take(6).ToList();
            return PartialView(values);
        }
        public PartialViewResult ModalPartial()
        {
            var values = context.ProjectDetails.ToList();
            return PartialView(values);
        }
        public PartialViewResult TeamPartial()
        {
            var values = context.Teams.ToList();
            return PartialView(values);
        }
        public PartialViewResult SocialMediaPartial()
        {
            var values = context.SocialMedias.ToList();
            return PartialView(values);
        }
        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }
        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult MastheadPartial()
        {
            var values = context.Features.ToList();
            return PartialView(values);
        }
        public PartialViewResult ServicePartial()
        {
            var values = context.Services.ToList();
            return PartialView(values);
        }
        public PartialViewResult AboutPartial()
        {
            var values = context.Abouts.OrderByDescending(x => x.AboutId).Take(6).ToList();
            return PartialView(values);
        }
        public PartialViewResult ClientPartial()
        {
            return PartialView();
        }
        // Mesajları Görüntüleme
        public PartialViewResult MessagePartial()
        {
            var values = context.Messages.OrderByDescending(m => m.SendDate).ToList();
            return PartialView(values);
        }

        // Mesaj Gönderme
        [HttpPost]
        public ActionResult SendMessage(Message message)
        {
            if (ModelState.IsValid)
            {
                message.SendDate = DateTime.Now;
                message.IsRead = false;
                context.Messages.Add(message);
                context.SaveChanges();
                TempData["SuccessMessage"] = "Mesajınız başarıyla gönderildi!";
                return RedirectToAction("Index", "Default");
            }
            TempData["ErrorMessage"] = "Lütfen tüm alanları doldurun!";
            return RedirectToAction("Index", "Default");
        }

        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }
        public PartialViewResult GoogleMapsPartial()
        {
            return PartialView();
        }
    }
}