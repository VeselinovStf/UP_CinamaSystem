using CinemaAPI.DateTimeWraper;
using SimpleInjector;
using SimpleInjector.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemAPI.IoCContainer
{
    public class UtilityPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<IDateTimeWrapper, DateTimeWrapper>();
        }
    }
}