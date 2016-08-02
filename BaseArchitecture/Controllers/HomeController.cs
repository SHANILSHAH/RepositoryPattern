using BaseArchitecture.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaseArchitecture.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var customer = BusinessLogicHelper.Instance.CustoperOperation;
            var x = customer.GetAll();
            //ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
