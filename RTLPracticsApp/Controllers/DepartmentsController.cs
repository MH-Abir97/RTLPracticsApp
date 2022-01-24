using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RTLPracticsApp.Data;
using RTLPracticsApp.Models;

namespace RTLPracticsApp.Controllers
{
    public class DepartmentsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Departments
        public ActionResult Index()
        {
            return View();
        }

        // GET: Departments/Details/5
        [HttpGet]
        public ActionResult GetData()
        {
            var deplist = db.Departments.ToList();
            return Json(deplist,JsonRequestBehavior.AllowGet);
        }
       
        [HttpPost]
        public ActionResult Save( Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return Json(true);
            }

            return Json(null,JsonRequestBehavior.AllowGet);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

       
        [HttpPost]
      
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Department department = db.Departments.Find(id);
         
            db.Departments.Remove(department);
           bool isSaved= db.SaveChanges() >0;
            if (isSaved)
            {
                return Json(true);
            }
            return Json(null,JsonRequestBehavior.AllowGet) ;
        }

        // POST: Departments/Delete/5
   

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
