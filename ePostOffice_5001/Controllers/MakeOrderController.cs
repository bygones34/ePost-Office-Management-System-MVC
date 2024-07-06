using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ePostOffice_5001.Models.Entity;

namespace ePostOffice_5001.Controllers
{
    public class MakeOrderController : Controller
    {
        // GET: MakeOrder

        epostofficeEntities db = new epostofficeEntities();

        [Authorize]
        public ActionResult MakeOrder()
        {
            return View();
        }       

        [HttpPost]        
        public ActionResult MakeOrder(TBL_ORDER p)
        {
            db.TBL_ORDER.Add(p);
            db.SaveChanges();
            return RedirectToAction("MakeOrder", "MakeOrder");

        }
    }
}