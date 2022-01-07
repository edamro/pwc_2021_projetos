using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P3_MVC_EF6_CF.DAL;
using P3_MVC_EF6_CF.Models;

namespace P3_MVC_EF6_CF.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = " ";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Aguardamos seu contato";

            return View();
        }
    }
}