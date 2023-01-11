using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalProject.Models
{
    [Table("tblUser")]
    public class User
    {
        //Had to create user class to allow for login
        //Users:
        //admin, 1234
        //user, 1234
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        public string Pass { get; set; }
    }
}