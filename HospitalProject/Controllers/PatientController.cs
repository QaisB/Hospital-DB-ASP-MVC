using HospitalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace HospitalProject.Controllers
{
    public class PatientController : Controller
    {
        ContextClass patientContext = new ContextClass();

        // GET: Patient
        public ActionResult Index(string SearchBy, string search) //General View of Patient Page
        {
            //If the button is on searchby NAme, search patients by that name, else search by doctor name
            if (SearchBy == "Name")
            {
                return View(patientContext.Patients.Where(p => p.Name.Contains(search) || search == null).Include(p => p.doctor).ToList());
            }
            else
            {
                return View(patientContext.Patients.Where(p => p.doctor.Name.Contains(search) || search == null).Include(p => p.doctor).ToList());
            }
        }

        public ActionResult Details(int id)
        {
            //use selected patient id to grab that patients details from db
            Patient patient = patientContext.Patients.Include("doctor").Single(p => p.Id == id);
            return View(patient);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Patient p = new Patient {DoctorList = new SelectList(patientContext.Doctors, "Id", "Name")};
            return View(p);
        }

        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            //if valid, add patient and redirect to index page
            if (ModelState.IsValid)
            {
                patientContext.Patients.Add(patient);
                patientContext.SaveChanges();
                return RedirectToAction("Index");
            }

            patient.DoctorList = new SelectList(patientContext.Doctors, "Id", "Name");
            return View(patient);
            

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            //use selected patient id to edit that row in table
            Patient pa = patientContext.Patients.Include("doctor").Single(p => p.Id == id);
            ViewBag.DoctorId = new SelectList(patientContext.Doctors, "Id", "Name");
            return View(pa);

        }

        [HttpPost]
        public ActionResult Edit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                patientContext.Entry(patient).State = EntityState.Modified;
                patientContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(patientContext.Doctors, "Id", "Name");
            return View(patient);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            //delete selected patient
            Patient patient = patientContext.Patients.Include("doctor").Single(p => p.Id == id);
            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = patientContext.Patients.Include("doctor").Single(p => p.Id == id);
            patientContext.Patients.Remove(patient);
            patientContext.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult DDL()
        {
            //this was just a method we created to test dropdown lists early on
            ViewBag.did = new SelectList(patientContext.Doctors, "Id","Name");
            return View();
        }
    }
}