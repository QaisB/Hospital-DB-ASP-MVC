using HospitalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalProject.Controllers
{
    public class DoctorController : Controller
    {
        //create instance of context class for CRUD
        ContextClass doctorContext = new ContextClass();

        // GET: Doctor
        public ActionResult Index(string SearchBy, string search) //General View of Doctors Page
        {
            //If the button is on searchby NAme, search doctors by that name, else search by office
            if (SearchBy == "Name")
            {
                return View(doctorContext.Doctors.Where(d => d.Name.Contains(search) || search == null).ToList());
            }
            else {
                return View(doctorContext.Doctors.Where(d => d.Office.Contains(search) || search == null).ToList());

            }

        }
        public ActionResult Details(int id) //Detail of selected Doctor
        {
            //use selected doctors id to grab that doctors details from db
            Doctor doctor = doctorContext.Doctors.Single(doc=>doc.Id==id);
            //LinQ

            return View(doctor);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Doctor doctor)
        {
            //if valid, add doctor and redirect to index page
            if (ModelState.IsValid){
                doctorContext.Doctors.Add(doctor);
                doctorContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctor);

        }

        public ActionResult Edit(int id)
        {
            //use selected doctor id to edit that row in table
            Doctor doctor = doctorContext.Doctors.Single(d => d.Id == id);
            return View(doctor);
        }

        [HttpPost]
        public ActionResult Edit(Doctor doctor)
        {
            //confirm edit to selected doctor
            if (ModelState.IsValid) {
                doctorContext.Entry(doctor).State = EntityState.Modified;
                doctorContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctor);

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            //delete selected doctor
            Doctor doctor = doctorContext.Doctors.Single(d => d.Id == id);
            return View(doctor);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            //actually remove that doctor
            Doctor doctor = doctorContext.Doctors.Single(d => d.Id == id);
            doctorContext.Doctors.Remove(doctor);
            doctorContext.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}