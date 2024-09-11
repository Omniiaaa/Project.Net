using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Net.Context;
using Project.Net.Models;

namespace Project.Net.Controllers
{
    public class ProductController : Controller
    {
        CompanyContext CompanyContext=new CompanyContext();
        [HttpGet]
        public IActionResult Index()
        {
            var products=CompanyContext.Products.Include(p=>p.Category);
            return View(products);
        }
        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var product = CompanyContext.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
            return View(product);
        }
        [HttpGet]
        public IActionResult Create()
        {  
            ViewBag.Categories=new SelectList(CompanyContext.Categories,"CategoryId","Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product) 
        {
            CompanyContext.Products.Add(product);
            CompanyContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            var product = CompanyContext.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(CompanyContext.Categories, "CategoryId", "Name");
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            var oldproduct = CompanyContext.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (oldproduct == null)
            {
                return RedirectToAction("Index");
            }
            oldproduct.Title = product.Title;
            oldproduct.ProductId = product.ProductId;
            oldproduct.Price = product.Price;
            oldproduct.Quantity = product.Quantity;
            oldproduct.Description = product.Description;
            oldproduct.CategoryId = product.CategoryId;
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
            var product = CompanyContext.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(int id, string confirm)
        {
            if (confirm == "Yes")
            {
                var product = CompanyContext.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
                if (product == null)
                {
                    return RedirectToAction("Index");
                }
                CompanyContext.Products.Remove(product);
                CompanyContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }


    }
}
