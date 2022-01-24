using RTLPracticsApp.Data;
using RTLPracticsApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RTLPracticsApp.Controllers
{
    public class ItemSelectController : Controller
    {
        // GET: ItemSelect
        private AppDbContext db = new AppDbContext();
       
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetData()
        {
            var orderItem =db.orders.Include(i => i.Item).ToList();
            List<Order> list = new List<Order>();

            foreach (var item in orderItem)
            {
                list.Add(new Order
                {
                 
                });
            }
            return Json(list,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult getSubmitData(string itemIds)
        {
            var convetData = itemIds.Split(',');

            List<Department> depList = new List<Department>();
            foreach (var item in convetData)
            {
                Department department = new Department();
                department = db.Departments.Find(Convert.ToInt32(item));
                depList.Add(department);
            }

            return Json(depList, JsonRequestBehavior.AllowGet);
        }

    }
}