using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektMove.Models
{
    public class Image_Model
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Ownership_Id { get; set; }
        [Required]
        public string Image_Name { get; set; }
       
        [Required]
        public string Directory { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}