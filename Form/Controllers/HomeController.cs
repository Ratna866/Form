using Form.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form.Controllers
{
    public class HomeController : Controller
    {
        studentcontext db = new studentcontext();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.students.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
                db.students.Add(s);
                int a = db.SaveChanges();
                if (a > 0)
                {
                //ViewBag.InsertMessage = "<script>alert('Data Inserted!!') </ script >";
                //TempData["InsertMessage"] = "<script>alert('Data Inserted')</script>";
                TempData["InsertMessage"] = "Data Inserted";
                return RedirectToAction("Index");
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Data not Inserted!!') </ script >";
                }
                return View();
            }
        public ActionResult Edit(int id)
        {
            var row = db.students.Where(model => model.ID == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(Student s)
        {
            db.Entry(s).State = EntityState.Modified;
            int a=db.SaveChanges();
            if(a>0)
            {
                //ViewBag.UpdateMessage = "<script>alert('Data Updated!!') </ script >";
                TempData["UpdateMessage"] = "Data Updated";
                ModelState.Clear();
            }
            else
            {
                //ViewBag.UpdateMessage = "<script>alert('Data Not Updated!!') </ script >";
                TempData["UpdateMessage"] = "Data Not Updated";
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            var StudentIdRow = db.students.Where(model => model.ID == id).FirstOrDefault();
            return View(StudentIdRow);
        }
        [HttpPost]
        public ActionResult Delete(Student s)
        {
            db.Entry(s).State = EntityState.Deleted;
            int a = db.SaveChanges();
            if(a>0)
            {
                TempData["DeleteMessage"] = "<script>alert('Data Deleted!!') </ script >";
            }
            else
            {
                TempData["DeleteMessage"] = "<script>alert('Data Not Deleted!!') </ script >";
            }
            return RedirectToAction("Index");
        }
    }
    }