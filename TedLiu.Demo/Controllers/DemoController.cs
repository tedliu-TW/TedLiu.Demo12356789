using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TedLiu.Demo.Models;
using TedLiu.Demo.Models.Service;
using X.PagedList;

namespace TedLiu.Demo.Controllers
{
    public class DemoController : Controller
    {
        DemoService service = new DemoService();
        // GET: Demo
        private int pageSize = 5;
        public ActionResult Index(int page=1)
        {
            var data = service.Getall().ToPagedList(page,pageSize);
            return View(data);
        }

        // GET: Demo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Demo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Demo/Create
        [HttpPost]
        public ActionResult Create(AddressBook model)
        {
            try
            {
                // TODO: Add insert logic here
                service.Create(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Demo/Edit/5
        public ActionResult Edit(int id)
        {
            var data =service.getId(id);
            return View(data);
        }

        // POST: Demo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AddressBook model)
        {
            try
            {
                // TODO: Add update logic here
                service.Edit(id,model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Demo/Delete/5
        public ActionResult Delete(int id)
        {
            var data = service.getId(id);
            return View(data);
        }

        // POST: Demo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                service.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
