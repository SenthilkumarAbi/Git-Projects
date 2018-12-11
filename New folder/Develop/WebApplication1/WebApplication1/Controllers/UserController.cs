using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterClone_MVC_WebAPI.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        // GET: Twitter
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SignUp(Person model)
        {

            return RedirectToAction("Login");
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Person model)
        {

            return RedirectToAction("Home","Twitter");
        }
    }
}