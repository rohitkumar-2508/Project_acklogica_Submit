using Project_acklogica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_acklogica.Controllers
{
    public class SaleController : Controller
    {
        Inventory_managementEntities db = new Inventory_managementEntities();
        // GET: Sale
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Display_Sale()
        {
            var list = db.sales.ToList();
            return View(list);

        }

        [HttpGet]
        public ActionResult SaleProduct()
        {
            List<string> list = db.products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }

        [HttpPost]
        public ActionResult SaleProduct(sale summ)
        {
            db.sales.Add(summ);
            db.SaveChanges();
            return RedirectToAction("Display_Sale");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = db.sales.Find(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(int id, sale sa)
        {

            db.Entry(sa).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Display_Sale");
        }


        public ActionResult Delete(int Categoryid)
        {
           
            var Category = db.sales.Find(Categoryid);
            db.sales.Remove(Category);
            db.SaveChanges();
            return RedirectToAction("Display_Sale");
        }



    }
}