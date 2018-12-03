using SampleExerciseDotNet2.Service;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace SampleExerciseDotNet2.App_Start
{
    public static class IOCConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<ICompanyService, CompanyService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }


    }
}