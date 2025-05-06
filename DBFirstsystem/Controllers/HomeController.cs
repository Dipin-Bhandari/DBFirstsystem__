using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBFirstsystem.Models;

namespace DBFirstsystem.Controllers
{
    public class HomeController : Controller
    {

        DBFirstsystemEntities db = new DBFirstsystemEntities();
        // GET: Home

        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
            // return View();
        }

        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(Student S)
        {
            if (ModelState.IsValid == true)
            {
                db.Students.Add(S);
                db.Students.Add(S);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('Inserted !!') </script>";
                    return RedirectToAction("Index");

                }
                else
                {
                    TempData["InsertMessage"] = "<script>alert('Not Inserted!!')</script>";
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var row = db.Students.Where(model => model.ID == id).FirstOrDefault();
            return View(row);

        }

        [HttpPost]
        public ActionResult Edit(Student S)
        {


            if (ModelState.IsValid == true)
            {
                db.Entry(S).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["UpdateMessage"] = "<script>alert('Upadated !!') </script>";
                    return RedirectToAction("Index");

                }
                else
                {
                    TempData["UpdateMessage"] = "<script>alert('Not Updated!!')</script>";
                }


            }
            return View();

        }

        public ActionResult Delete(int id)
        {
            var deleted_row = db.Students.Where(model => model.ID == id).FirstOrDefault();
            return View(deleted_row);



        }

        public ActionResult Details(int id)
        {
            var row = db.Students.Where(model => model.ID == id).FirstOrDefault();
            return View(row);






            //[HttpPost]
            //public ActionResult Delete(Student S)
            //{


            //    if (ModelState.IsValid == true)
            //    {
            //        db.Entry(S).State = EntityState.Deleted;
            //        int a = db.SaveChanges();
            //        if (a > 0)
            //        {
            //            TempData["DeleteMessage"] = "<script>alert('Deleted !!') </script>";
            //            return RedirectToAction("Index");

            //        }
            //        else
            //        {
            //            TempData["DeleteMessage"] = "<script>alert('Not Deleted!!')</script>";
            //        }


            //    }
            //    return View();

            //}
        }
    }
}