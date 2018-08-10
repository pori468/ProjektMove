using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektMove.Models
{
    public class Person_Info_Model
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [Display (Name = "Phone")]

        public int Phone_No { get; set; }
        [Required]
        [Display(Name = "Speciality")]
        public string Category { get; set; }
       
        public bool Volunteer { get; set; }
       
        public bool Leader { get; set; }
        public bool Approved { get; set; }
        public bool Contac { get; set; }

        [Display(Name = "Emai Confirmation")]
        public bool Email_Verification { get; set; }
        public DateTime Date { get; set; }

       
        public string Ownership_Id { get; set; }
    }

    public class Member_ViewModel
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public int Phone_No { get; set; }

        [Required]
        [Display(Name = "Speciality")]
        public string Category { get; set; }

        public bool Volunteer { get; set; }

        public bool Leader { get; set; }
        public bool Contac { get; set; }

        public bool Approved { get; set; }
        public DateTime Date { get; set; }


        public string Ownership_Id { get; set; }
    }
}