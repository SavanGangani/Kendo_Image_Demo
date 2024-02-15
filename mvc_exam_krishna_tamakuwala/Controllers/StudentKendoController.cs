using mvc_exam_krishna_tamakuwala.Bal;
using mvc_exam_krishna_tamakuwala.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_exam_krishna_tamakuwala.Controllers
{
    public class StudentKendoController : Controller
    {
        StudentHelper studentHelper = new StudentHelper();

        // GET: StudentKendo
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAll()
        {
            return Json(studentHelper.GetAll(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(t_studenttable student)
        {
            return Json(studentHelper.Add(student), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(t_studenttable student)
        {
            return Json(studentHelper.Update(student), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(t_studenttable student)
        {
            return Json(studentHelper.Delete(student.c_id), JsonRequestBehavior.AllowGet);
        }
    }
}
