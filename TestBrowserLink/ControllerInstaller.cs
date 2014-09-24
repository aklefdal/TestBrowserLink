using System.Web.Mvc;

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using TestBrowserLink.Controllers;

namespace TestBrowserLink
{
    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromThisAssembly()
                    .BasedOn<IController>()
                    .If(Component.IsInSameNamespaceAs<HomeController>())
                    .If(t => t.Name.EndsWith("Controller"))
                    .LifestyleTransient());
        }
    }
}