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
    public class DepartmentsTestController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: DepartmentsTest
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetDataList()
        {
            var dep = db.Departments.ToList();
            return Json(dep,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetDropdownList(string categoryIds)
        {
             var convetData = categoryIds.Split(',');

            List<Department> depList = new List<Department>();
            foreach (var item in convetData)
            {
                Department department = new Department();
                department = db.Departments.Find(Convert.ToInt32(item));
                depList.Add(department);
            }

            return Json(depList, JsonRequestBehavior.AllowGet);
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
