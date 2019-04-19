using CinemaAPI.DateTimeWraper;
using SimpleInjector;
using SimpleInjector.Packaging;

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