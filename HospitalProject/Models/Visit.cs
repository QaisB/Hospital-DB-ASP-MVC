using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalProject.Models
{
    //connect to visit table
    [Table("tblVisit")]

    public class Visit
    {
        //get visit fields, and validate 
        //also get foreign keys from doctor and patient table
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Visit Date")]
        public DateTime VisitDate { get; set; }

        [Required(ErrorMessage = "Please enter Complaint")]
        public string Complaint { get; set; }

        public DateTime? LeaveDate { get; set; }


        [Required(ErrorMessage = "Please enter Doctor")]
        public int DoctorId { get; set; }

        [ForeignKey("DoctorId")]
        public Doctor doctor { get; set; } //Object of foreign key table Doctor Model

        
        [Required(ErrorMessage = "Please enter Patient")]
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient patient { get; set; } //Object of foreign key table Patient Model

        public IEnumerable<SelectListItem> DList { get; set; }
        public IEnumerable<SelectListItem> PList { get; set; }



    }

}