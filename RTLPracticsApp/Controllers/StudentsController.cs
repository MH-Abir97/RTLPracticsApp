using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RTLPracticsApp.Data;
using RTLPracticsApp.Models;

namespace RTLPracticsApp.Controllers
{
    public class StudentsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Students
        public ActionResult Index()
        {
            return View();
        }

       [HttpPost]
        public ActionResult DataSavedList(List<Student>studentList)
        {
            if (ModelState.IsValid)
            {
                Student student = new Student();
                var stuId = student.Id;
                if (stuId==0)
                {
                    foreach (var item in studentList)
                    {
                        db.Student.Add(item);
                    }
                }
                else
                {
                  
                    foreach (var item in studentList)
                    {
                      //  db.Student.AddOrUpdate(item);
                        db.Entry(item).State = EntityState.Modified;
                    }
                }
              
                db.SaveChanges();
            }
            return Json (studentList,JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetAllData()
        {
            var data = db.Student.ToList();
            return Json(data,JsonRequestBehavior.AllowGet);
        }
     
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
