using RTLPracticsApp.Data;
using RTLPracticsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RTLPracticsApp.Controllers
{
    public class TestCatController : Controller
    {
        // GET: TestCat
        private AppDbContext db = new AppDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllDepartment()
        {
            var dep = db.Departments.ToList();
            return Json(dep, JsonRequestBehavior.AllowGet);
        }

        
        [HttpGet]
        public JsonResult GetAllStudent()
        {
            var dep = db.Student.ToList();
            return Json(dep, JsonRequestBehavior.AllowGet);
        }
        // GET: TestCat/Details/5

        [HttpGet]
        public JsonResult GetStudentId()
        {
            var stuId = db.Student.FirstOrDefault();

            return Json(stuId,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public int StudentSave(Student student)
        {
            int ret = 0;
            if (student.Id== 0)
            {
                db.Student.Add(student);
                db.SaveChanges();
            }
         
            return ret;
        }
        //[HttpPost]
        //public JsonResult SaveNew(Department dept)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Departments.Add(dept);
        //        bool isSave = db.SaveChanges() > 0;
        //        if (isSave)
        //        {
        //            Json(true);
        //        }

        //    }
        //    return Json(null,JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
      public JsonResult SaveDept(Department dept)
      {
          
            if (ModelState.IsValid)
            {
                db.Departments.Add(dept);
                db.SaveChanges();
                return Json(dept);
            }
            return Json(false);
        }

        
    }
}
