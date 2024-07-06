using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ePostOffice_5001.Models.Entity;

namespace ePostOffice_5001.Controllers
{
    [Authorize(Roles = "A")]
    public class OrdersController : Controller
    {
        // GET: Orders
        epostofficeEntities db = new epostofficeEntities();
        public ActionResult Orders()
        {
            var vars = db.TBL_ORDER.ToList();
            return View(vars);
        }

        [HttpGet]
        public ActionResult NewOrder()
        {           
            return View();
        }

        [HttpPost]
        public ActionResult NewOrder(TBL_ORDER p2)
        {
            db.TBL_ORDER.Add(p2);
            db.SaveChanges();
            return View();
        }

        public ActionResult Delete(int id)
        {
            var orders = db.TBL_ORDER.Find(id);
            db.TBL_ORDER.Remove(orders);
            db.SaveChanges();
            return RedirectToAction("Orders", "Orders");
        }
    }
}