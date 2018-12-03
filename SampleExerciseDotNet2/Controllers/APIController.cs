using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SampleExerciseDotNet2.Models;

namespace SampleExerciseDotNet2.Controllers
{
    public class APIController : Controller
    {
        // GET
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QueryTweets()
        {
            var model = new List<Tweets>();

            try
            {
                string companyName = Request.QueryString["company"];
                ViewBag.CompanyName = companyName.ToUpper();

                Twitter twitter = new Twitter();
                IEnumerable<string> tweets = twitter.GetTweets(companyName, 10).Result;

                foreach (var t in tweets)
                {
                    Tweets Tweet = new Tweets();

                    Tweet.Text = t.Substring(t.IndexOf("-~-") + 3);
                    Tweet.Username = companyName;
                    Tweet.Url = "https://twitter.com/" + companyName + "/status/" + t.Substring(0, t.IndexOf("-~-"));
                    model.Add(Tweet);
                }
            }
            catch (Exception ex)
            {
                //Log the Message in the Database with ex.Message
            }

            return View(model);
        }
    }
}