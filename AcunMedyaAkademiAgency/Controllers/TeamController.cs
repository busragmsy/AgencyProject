using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiAgency.Context;
using AcunMedyaAkademiAgency.Entities;

namespace AcunMedyaAkademiAgency.Controllers
{
    public class TeamController : Controller
    {
        // GET: Team
        AgencyContext context = new AgencyContext();
        public ActionResult TeamList(string searchText)
        {
            List<Team> values;
            if (searchText != null)
            {
                values = context.Teams.Where(x => x.NameSurname.Contains(searchText)).ToList();
                return View(values);
            }
            values = context.Teams.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateTeam()
        {
            List<SelectListItem> values1 = (from x in context.Branches.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.BranchName,
                                                Value = x.BranchId.ToString()
                                            }).ToList();
            ViewBag.v = values1;
            return View();
        }
        [HttpPost]
        public ActionResult CreateTeam(Team team)
        {
            context.Teams.Add(team);
            context.SaveChanges();

            return RedirectToAction("TeamList");
        }
        public ActionResult DeleteTeam(int id)
        {
            var value = context.Teams.Find(id);
            context.Teams.Remove(value);
            context.SaveChanges();
            return RedirectToAction("TeamList");
        }
        [HttpGet]
        public ActionResult UpdateTeam(int id)
        {
            List<SelectListItem> value = (from x in context.Branches.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.BranchName,
                                              Value = x.BranchId.ToString()
                                          }).ToList();
            ViewBag.cat = value;
            var values = context.Teams.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateTeam(Team team)
        {
            var value = context.Teams.Find(team.TeamId);
            value.NameSurname = team.NameSurname;
            value.ImageUrl = team.ImageUrl;
            value.Gender = team.Gender;
            value.City = team.City;
            value.BranchId = team.BranchId;
            context.SaveChanges();

            return RedirectToAction("TeamList");
        }
    }
}