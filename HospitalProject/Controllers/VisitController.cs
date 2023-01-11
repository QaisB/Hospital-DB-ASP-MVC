using HospitalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace HospitalProject.Controllers
{
    public class VisitController : Controller
    {
        ContextClass visitContext = new ContextClass();

        // GET: Visit

        public ActionResult Index(string SearchBy, string search) //General View of Visit Page
        {
            //searchby either patient name or doctor name
            
            if (SearchBy == "PName")
            {
                return View(visitContext.Visits.Where(v => v.patient.Name.Contains(search) || search == null).Include("patient").Include("doctor").ToList());
            }
            else
            {
                return View(visitContext.Visits.Where(v => v.doctor.Name.Contains(search) || search == null).Include("patient").Include("doctor").ToList());
            }
        }

        public ActionResult Details(int id) //get visit details
        {
            Visit visit = visitContext.Visits.Include("patient").Include("doctor").Single(v => v.Id == id);
            return View(visit);
        }

        [HttpGet]
        public ActionResult Create() //create visit
        {
            Visit v = new Visit {DList = new SelectList(visitContext.Doctors, "Id", "Name"),
                PList = new SelectList(visitContext.Patients, "Id", "Name")
            };
            return View(v);
        }

        [HttpPost]
        public ActionResult Create(Visit visit) //confirm visit creation
        {

            if (ModelState.IsValid)
            {
                visitContext.Visits.Add(visit);
                visitContext.SaveChanges();
                return RedirectToAction("Index");
            }
            Visit v = new Visit{
                DList = new SelectList(visitContext.Doctors, "Id", "Name"),
                PList = new SelectList(visitContext.Patients, "Id", "Name")
            };
            return View(v);



        }
        [HttpGet]
        public ActionResult Edit(int id) //edit a selected visit with its id
        {
            Visit visit = visitContext.Visits.Include("patient").Include("doctor").Single(p => p.Id == id);
            ViewBag.DoctorId = new SelectList(visitContext.Doctors, "Id", "Name");
            ViewBag.PatientId = new SelectList(visitContext.Patients, "Id", "Name");
            return View(visit);
        }

        [HttpPost]
        public ActionResult Edit(Visit visit) //confirm visit edit
        {
            if (ModelState.IsValid){
                visitContext.Entry(visit).State = EntityState.Modified;
                visitContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(visitContext.Doctors, "Id", "Name");
            ViewBag.PatientId = new SelectList(visitContext.Patients, "Id", "Name");
            return View(visit);

        }

        [HttpGet]
        public ActionResult Delete(int id) //delete a visit 
        {
            Visit visit = visitContext.Visits.Single(v => v.Id == id);
            return View(visit);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id) //confirm visit deletion
        {
            Visit visit = visitContext.Visits.Single(v => v.Id == id);
            visitContext.Visits.Remove(visit);
            visitContext.SaveChanges();

            return RedirectToAction("Index");

        }


    }
}