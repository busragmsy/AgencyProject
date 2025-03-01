using AcunMedyaAkademiAgency.Context;
using AcunMedyaAkademiAgency.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaAkademiAgency.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        AgencyContext context = new AgencyContext();
        public ActionResult ProjectList(string searchText)
        {
            List<Project> values;
            if (searchText != null)
            {
                values = context.Projects.Where(x => x.Title.Contains(searchText)).ToList();
                return View(values);
            }

            values = context.Projects.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateProject()
        {
            List<SelectListItem> values1 = (from x in context.Categories.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryId.ToString()
                                            }).ToList();
            ViewBag.v = values1;

            return View();
        }
        [HttpPost]
        public ActionResult CreateProject(Project project)
        {
            context.Projects.Add(project);
            context.SaveChanges();
            return RedirectToAction("ProjectList");
        }
        public ActionResult DeleteProject(int id)
        {
            var value = context.Projects.Find(id);
            context.Projects.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ProjectList");
        }
        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            List<SelectListItem> value = (from x in context.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryName,
                                              Value = x.CategoryId.ToString()
                                          }).ToList();
            ViewBag.cat = value;
            var values = context.Projects.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateProject(Project project)
        {
            var value = context.Projects.Find(project.ProjectId);
            value.Title = project.Title;
            value.ImageUrl = project.ImageUrl;
            value.CategoryId = project.CategoryId;
            context.SaveChanges();

            return RedirectToAction("ProjectList");
        }
    }
}