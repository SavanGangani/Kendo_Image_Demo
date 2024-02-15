using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc_exam_krishna_tamakuwala.Models
{
    public class t_usertable
    {
        public int c_userid { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username must be required!")]
        public string c_username { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email must be required!")]
        public string c_email { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender must be required!")]
        public string c_gender { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password must be required!")]
        public string c_password { get; set; }
    }
}