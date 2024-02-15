using mvc_exam_krishna_tamakuwala.Bal;
using mvc_exam_krishna_tamakuwala.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_exam_krishna_tamakuwala.Controllers
{
    public class StudentController : Controller
    {
        StudentHelper studentHelper = new StudentHelper();

        // GET: Student
        public ActionResult Index()
        {
            HttpCookie email = Request.Cookies["email"];
            HttpCookie password = Request.Cookies["password"];

            //if(Session["userid"] == null)
            if ((email == null && password == null) || Session["userid"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            List<t_studenttable> studentList = studentHelper.GetAll();
            return View(studentList);
        }

        public ActionResult Details(int id)
        {
            HttpCookie email = Request.Cookies["email"];
            HttpCookie password = Request.Cookies["password"];

            //if (Session["userid"] == null)
            if ((email == null && password == null) || Session["userid"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            t_studenttable student = studentHelper.GetOne(id);
            return View(student);
        }

        public ActionResult Add()
        {
            HttpCookie email = Request.Cookies["email"];
            HttpCookie password = Request.Cookies["password"];

            //if (Session["userid"] == null)
            if ((email == null && password == null) || Session["userid"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Add(t_studenttable student)
        {
            HttpCookie email = Request.Cookies["email"];
            HttpCookie password = Request.Cookies["password"];

            //if (Session["userid"] == null)
            if ((email == null && password == null) || Session["userid"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            studentHelper.Add(student);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            HttpCookie email = Request.Cookies["email"];
            HttpCookie password = Request.Cookies["password"];

            //if (Session["userid"] == null)
            if ((email == null && password == null) || Session["userid"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            t_studenttable student = studentHelper.GetOne(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(t_studenttable student)
        {
            HttpCookie email = Request.Cookies["email"];
            HttpCookie password = Request.Cookies["password"];

            //if (Session["userid"] == null)
            if ((email == null && password == null) || Session["userid"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            studentHelper.Update(student);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpCookie email = Request.Cookies["email"];
            HttpCookie password = Request.Cookies["password"];

            //if (Session["userid"] == null)
            if ((email == null && password == null) || Session["userid"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            studentHelper.Delete(id);
            return RedirectToAction("Index");
        }
    }
}