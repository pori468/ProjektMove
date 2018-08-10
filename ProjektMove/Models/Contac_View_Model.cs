using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektMove.Models
{
    public class Contac_View_Model
    {
       
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public int Phone { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }
    }

    public class Contac_Person_Model
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone_No { get; set; }

        public string Ownership_Id { get; set; }


    }
}