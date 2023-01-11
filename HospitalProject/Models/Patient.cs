using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalProject.Models
{
    //Connect to patient table
    [Table("tblPatient")]

    public class Patient
    {
        //List fields from patient table
        //Also field validation
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [EmailAddress(ErrorMessage = "Email address is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter Telephone")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Please enter Dob")]
        public DateTime Dob { get; set; }


        //Have to get foreign key from doctor table to use in controller to connect

        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor doctor { get; set; } //Object of foreign key table Doctor Model

        public IEnumerable<SelectListItem> DoctorList { get; set; }

    }
}