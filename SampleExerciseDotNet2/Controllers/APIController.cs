using System.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using SampleExerciseDotNet2.Models;
using SampleExerciseDotNet2.Service;

namespace SampleExerciseDotNet2.Controllers
{
    public class APIController : Controller
    {
        private ICompanyService icompanyservice;

        public APIController(ICompanyService icompanyservice)
        {
            this.icompanyservice = icompanyservice;
        }

        // GET: Broadcast
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QueryTweets()
        {
            //to do try catch

            string companyName = this.icompanyservice.GetCompany();
            ViewBag.CompanyName = companyName.ToUpper();

            Twitter twitter = new Twitter();
            IEnumerable<string> tweets = twitter.GetTweets(companyName, 10).Result;

            var model = new List<Tweets>();

            foreach (var t in tweets)
            {
                Tweets Tweet = new Tweets();

                Tweet.Text = t.Substring(t.IndexOf("-~-")+3);
                Tweet.Username = companyName;
                Tweet.Url = "https://twitter.com/" + companyName + "/status/" + t.Substring(0, t.IndexOf("-~-"));
                model.Add(Tweet);
            }

            return View(model);
        }
    }
}