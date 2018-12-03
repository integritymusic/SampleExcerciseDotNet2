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
        //Dependency Injection Example - Stubbed out Company finder service
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

    }
}