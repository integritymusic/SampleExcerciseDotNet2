using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleExerciseDotNet2.Service
{
    public class CompanyService : ICompanyService
    {
        public string GetCompany()
        {
            //method to get the company username for the twitter feed
            return "nfl";
        }
    }
}