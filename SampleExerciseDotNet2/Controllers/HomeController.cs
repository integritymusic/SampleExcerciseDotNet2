using SampleExerciseDotNet2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleExerciseDotNet2.Controllers
{
    public class HomeController : Controller
    {
        private ICompanyService icompanyservice;

        public HomeController(ICompanyService icompanyservice)
        {
            this.icompanyservice = icompanyservice;
        }

        public ActionResult Index()
        {
            string companyName = this.icompanyservice.GetCompany();
            ViewBag.CompanyName = companyName.ToUpper();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult QueryTweets()
        {
            return View();
        }
    }
}