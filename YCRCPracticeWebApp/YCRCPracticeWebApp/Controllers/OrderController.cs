using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YCRCPracticeWebApp.Models.ViewModels;

namespace YCRCPracticeWebApp.Controllers
{
    /// <summary>
    /// Class OrderController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class OrderController : Controller
    {



        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {           
            return View();
        }
    }
}