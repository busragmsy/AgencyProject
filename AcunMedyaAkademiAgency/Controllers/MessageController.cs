using AcunMedyaAkademiAgency.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiAgency.Entities;
using Newtonsoft.Json.Linq;

namespace AcunMedyaAkademiAgency.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        AgencyContext context = new AgencyContext();
        public ActionResult MessageList(string searchText)
        {
            List<Message> values = new List<Message>();
            if (!string.IsNullOrEmpty(searchText))
            {
                values = context.Messages.Where(x => x.NameSurname.Contains(searchText)).ToList();
                return View(values);
            }
            values = context.Messages.ToList();
            return View(values);
        }
        public ActionResult DeleteMessage(int id)
        {
            var value = context.Messages.Find(id);
            context.Messages.Remove(value);
            context.SaveChanges();
            return RedirectToAction("MessageList");
        }

        public ActionResult MessageDetail(int id)
        {
            var value = context.Messages.Find(id);
            return View(value);
        }
    }
}