using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalProject.Models
{
    //Connect to doctor table
    [Table("tblDoctor")] 

    public class Doctor
    {
        //List fields from doctor table
        //Also field validation
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Name")] 
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Office")]
        public string Office { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [EmailAddress(ErrorMessage = "Email address is not valid")] 
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Telephone")] 
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Please enter Address")]
        public string Address { get; set; }


    }
}