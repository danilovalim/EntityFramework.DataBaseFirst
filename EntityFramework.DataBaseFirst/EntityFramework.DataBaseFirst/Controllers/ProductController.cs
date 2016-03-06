using EntityFramework.DataBaseFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET.MVC.EF.CodeFirst.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            using (StoreContext db = new StoreContext())
            {
                var products = db.Products.ToList();
                return View(products);
            }
        }

        public ActionResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                using (StoreContext db = new StoreContext())
                {
                    db.Products.Add(p);
                    db.SaveChanges();
                    return RedirectToAction("List");
                }
            }
            else
            {
                return View(p);
            }
        }

        public ActionResult Edit(int id)
        {
            using (StoreContext db = new StoreContext())
            {
                var prod = db.Products.Find(id);
                return View(prod);
            }
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            using (StoreContext db = new StoreContext())
            {
                var prod = db.Products.Where(x => x.ProductID == p.ProductID).First();
                prod.Name = p.Name;
                prod.Description = p.Description;
                prod.Price = p.Price;
                db.SaveChanges();
                return RedirectToAction("List");
            }
        }

        public ActionResult Details(int id)
        {
            using (StoreContext db = new StoreContext())
            {
                Product prod = db.Products.Find(id);
                return View(prod);
            }
        }
           


        public ActionResult Delete(int id)
        {
            using (StoreContext db = new StoreContext())
            {
                Product prod = db.Products.Find(id);
                return View(prod);
            }
        }

        [HttpPost]
        public ActionResult Delete(Product p, int id)
        {
            using (StoreContext db = new StoreContext())
            {
                Product prod = db.Products.Find(id);
                db.Products.Remove(prod);
                db.SaveChanges();
                return RedirectToAction("List");
            }
        }
    }
}