using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using FlexSoft.Infrastructure;
using FlexSoft.Services;

namespace FlexSoft.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();

            RegisterComponents(builder);
            var container = builder.Build();
            
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private static void RegisterComponents(ContainerBuilder builder)
        {
            builder.RegisterType<FlexSoftDbContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<Repository>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<UserManager>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<UserStore>().AsSelf().InstancePerRequest();
        }
    }
}
