using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Net.Context;
using Project.Net.Models;

namespace Project.Net.Controllers
{
    public class CategoryController : Controller
    {
        CompanyContext CompanyContext = new CompanyContext();
        [HttpGet]
        public IActionResult Index()
        {
            var categories = CompanyContext.Categories.ToList();
            ViewBag.Categories = categories;
            return View();
        }
        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var category = CompanyContext.Categories.Find(id);
            ViewBag.Categories = category;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            CompanyContext.Categories.Add(category);
            CompanyContext.SaveChanges();
            return RedirectToAction("index");

        }
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            var category = CompanyContext.Categories.FirstOrDefault(ct => ct.CategoryId == id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(CompanyContext.Categories, "CategoryId", "Name");
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            var oldcategory = CompanyContext.Categories.FirstOrDefault(ct => ct.CategoryId == category.CategoryId);
            if (oldcategory == null)
            {
                return RedirectToAction("Index");
            }
            oldcategory.CategoryId = category.CategoryId;
            oldcategory.Name = category.Name;
            oldcategory.Description = category.Description;
            CompanyContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            var category = CompanyContext.Categories.FirstOrDefault(ct => ct.CategoryId == id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Delete(int id, string confirm)
        {
            if (confirm == "Yes")
            {
                var category = CompanyContext.Categories.FirstOrDefault(ct => ct.CategoryId == id);
                if (category == null)
                {
                    return RedirectToAction("Index");
                }
                CompanyContext.Categories.Remove(category);
                CompanyContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
