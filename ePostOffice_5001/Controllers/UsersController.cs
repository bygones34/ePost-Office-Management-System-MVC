using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ePostOffice_5001.Models.Entity;


namespace ePostOffice_5001.Controllers
{
    [Authorize(Roles = "A")]
    public class UsersController : Controller
    {

        epostofficeEntities db = new epostofficeEntities();
       
        public ActionResult Users(string p)
        {
            var users = from d in db.TBLUSER select d;
            if(!string.IsNullOrEmpty(p))
            {
                users = users.Where(m => m.USERNAME.Contains(p));
            }
            return View(users.ToList());
            /*var users = db.TBLUSER.ToList();
            return View(users);*/
        }
        [HttpGet]
        public ActionResult NewUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewUser(TBLUSER p1)
        {
            db.TBLUSER.Add(p1);
            db.SaveChanges();
            return View();

        }
        public ActionResult Delete(int id)
        {
            var users = db.TBLUSER.Find(id);
            db.TBLUSER.Remove(users);
            db.SaveChanges();
            return RedirectToAction("Users", "Users");
        }
    }
}