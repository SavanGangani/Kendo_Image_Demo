using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mvc_exam_krishna_tamakuwala.Models
{
    public class t_studenttable
    {
        [Display(Name = "Student Id")]
        public int c_id { get; set; }

        [Display(Name = "Student Name")]
        public string c_name { get; set; }

        [Display(Name = "Student Image")]
        public string c_image { get; set; }
    }
}