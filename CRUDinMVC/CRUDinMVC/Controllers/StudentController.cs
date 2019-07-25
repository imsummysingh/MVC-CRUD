using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDinMVC.Models;

namespace CRUDinMVC.Controllers
{
    public class StudentController : Controller
    {

        //******************Retrieve Student Details**********************
        // GET: Student
        public ActionResult Index()
        {
            StudentHandle dbhandle = new StudentHandle();
            ModelState.Clear();
            return View(dbhandle.GetStudent());
        }        

        //********************Add New Student*******************************
        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentModel smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    StudentHandle sdb = new StudentHandle();
                    if (sdb.AddStudent(smodel))
                    {
                        ViewBag.Message = "Record Added Successfully";
                        ModelState.Clear();
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        //****************************EDIT STUDENT DETAILS********************
        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            StudentHandle sdb = new StudentHandle();
            return View(sdb.GetStudent().Find(smodel=>smodel.Id==id));
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StudentModel smodel)
        {
            try
            {
                StudentHandle sdb = new StudentHandle();
                sdb.UpdateDetails(smodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        //************************DELETE STUDENT DATA*****************************
        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                StudentHandle sdb = new StudentHandle();
                if (sdb.DeleteStudent(id))
                {
                    ViewBag.AlertMsg = "Student Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {

                return View();
            }            
        }
                
    }
}
