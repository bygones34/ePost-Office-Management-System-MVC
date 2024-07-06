using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ePostOffice_5001.Models.Entity;

namespace ePostOffice_5001.Controllers
{
    [Authorize(Roles = "A")]
    public class CategoryController : Controller
    {
        epostofficeEntities db = new epostofficeEntities();
        public ActionResult Category()
        {
            var cats = db.TBLCATEGORY.ToList();
            return View(cats);
        }

        [HttpGet]
        public ActionResult NewCategory()
        {
            
            return View();
        }

        
        [HttpPost]
        public ActionResult NewCategory(TBLCATEGORY p1)
        {
            db.TBLCATEGORY.Add(p1);
            db.SaveChanges();
            return View();

        }

        public ActionResult Delete(int id)
        {
            var categori = db.TBLCATEGORY.Find(id);
            db.TBLCATEGORY.Remove(categori);
            db.SaveChanges();
            return RedirectToAction("Category", "Category");
        }

    }

    
}