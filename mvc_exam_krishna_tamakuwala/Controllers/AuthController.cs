using mvc_exam_krishna_tamakuwala.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_exam_krishna_tamakuwala.Bal;
using System.Data;
using System.Configuration;

namespace mvc_exam_krishna_tamakuwala.Controllers
{
    public class AuthController : Controller
    {
        AuthHelper authHelper = new AuthHelper();

        public ActionResult Login()
        {
            HttpCookie email = Request.Cookies["email"];
            HttpCookie password = Request.Cookies["password"];
            if (email != null && password != null)
            {
                ViewBag.email = email.Value;
                ViewBag.password = password.Value;
            }
            else
            {
                ViewBag.email = "";
                ViewBag.password = "";
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(VM_Login user)
        {
            t_usertable loggedInUser = authHelper.Login(user);
            if (loggedInUser.c_userid != 0)
            {
                HttpCookie email = Request.Cookies["email"];
                HttpCookie password = Request.Cookies["password"];

                if (email == null || password == null)
                {
                    if (user.rememberMe == true)
                    {
                        Response.Cookies["email"].Expires = DateTime.Now.AddSeconds(10);
                        Response.Cookies["password"].Expires = DateTime.Now.AddSeconds(10);
                    }
                    else
                    {
                        Response.Cookies["email"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["password"].Expires = DateTime.Now.AddDays(-1);
                    }
                    Response.Cookies["email"].Value = user.c_email;
                    Response.Cookies["password"].Value = user.c_password;
                }
                return RedirectToAction("Index", "Student");
            }
            ViewBag.status = "error";
            ViewBag.message = "Invalid Credentials!";
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(t_usertable user)
        {
            if(authHelper.Register(user))
            {
                return RedirectToAction("Login");
            }
            return RedirectToAction("Register");
        }

        public bool IsEmailExists(string email)
        {
            return authHelper.IsEmailExists(email);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return View();
        }
    }
}