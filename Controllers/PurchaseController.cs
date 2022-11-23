using Project_acklogica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_acklogica.Controllers
{
    
    public class PurchaseController : Controller
    {
        Inventory_managementEntities db = new Inventory_managementEntities();
        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Display_Purchase()
        {
            var list = db.purchases.ToList();
            return View(list);
            
        }

        [HttpGet]
        public ActionResult PurchaseProduct()
        {
            List<string> list=db.products.Select(x=>x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }

        [HttpPost]
        public ActionResult PurchaseProduct(purchase pur)
        {
            db.purchases.Add(pur);
            db.SaveChanges();
            return RedirectToAction("Display_Purchase");
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            sale s = db.sales.Where(x => x.id == id).SingleOrDefault();
            return View(s);

        }

            [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = db.purchases.Find(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(int id,purchase pro)
        {
            
            db.Entry(pro).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Display_Purchase");
        }



    }
}