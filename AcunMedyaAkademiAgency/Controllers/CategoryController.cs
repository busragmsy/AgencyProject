using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiAgency.Context;
using AcunMedyaAkademiAgency.Entities;

namespace AcunMedyaAkademiAgency.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        AgencyContext context = new AgencyContext();
        public ActionResult CategoryList(string searchText)
        {
            List<Category> values;
            if (searchText != null)
            {
                values = context.Categories.Where(x => x.CategoryName.Contains(searchText)).ToList();
                return View(values);
            }
            values = context.Categories.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateCategory()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();

            return RedirectToAction("CategoryList");
        }
        public ActionResult DeleteCategory(int id)
        {
            var value = context.Categories.Find(id);
            context.Categories.Remove(value);
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var category = context.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                var existingCategory = context.Categories.Find(category.CategoryId);
                if (existingCategory != null)
                {
                    existingCategory.CategoryName = category.CategoryName;
                    context.SaveChanges();
                }
                return RedirectToAction("CategoryList");
            }
            return View(category);
        }
    }
}