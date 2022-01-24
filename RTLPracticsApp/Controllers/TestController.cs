using RTLPracticsApp.Data;
using RTLPracticsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RTLPracticsApp.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        private AppDbContext db = new AppDbContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetAllDepartment()
        {
            var dep = db.Departments.ToList();
            return Json(dep, JsonRequestBehavior.AllowGet);
        }
       public int DeptAndStudentSave(List<Student> studentList, List<Department>DeptList,List<Order>orderListItem)
        {
            int ret = 0;

            foreach (var studentItem in studentList)
            {
                 db.Student.Add(studentItem);
            }
            db.SaveChanges();
            foreach (var deptItem in DeptList)
            {
                db.Departments.Add(deptItem);
            }
            db.SaveChanges();

            foreach (var item in orderListItem)
            {
                db.orders.Add(item);
            }
            db.SaveChanges();

            return ret;
        }
    }
}