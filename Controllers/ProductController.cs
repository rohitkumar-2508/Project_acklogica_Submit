using Project_acklogica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_acklogica.Controllers
{
    public class ProductController : Controller
    {
        Inventory_managementEntities db = new Inventory_managementEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ProductList()
        {
            var user=db.products.ToList();
            return View(user);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(product category)
        {
            db.products.Add(category);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = db.products.Find(id);
            return View(user);
        }


        [HttpPost]
        public ActionResult Edit(product pro)
        {
            var user = db.products.ToList();
            return View(user);
        }



    
        public ActionResult Delete(int id)
        {
           
            var Category = db.products.Find(id);
            db.products.Remove(Category);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }



    }
}