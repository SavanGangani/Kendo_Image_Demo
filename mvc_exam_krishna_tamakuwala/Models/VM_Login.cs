using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc_exam_krishna_tamakuwala.Models
{
    public class VM_Login
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email must be required!")]
        public string c_email { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password must be required!")]
        public string c_password { get; set; }

        [Display(Name = "Remeber Me")]
        public bool rememberMe { get; set; }
    }
}