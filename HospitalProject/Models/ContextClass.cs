using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace HospitalProject.Models
{
    public class ContextClass:DbContext
    {
        //In this class we connect to the DB and create a session with the db
        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Visit> Visits { get; set; }

        public DbSet<User> Users { get; set; }

    }
}