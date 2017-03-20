using GastosBack_ConsoleApp.Repository;
using Microsoft.Practices.Unity;
using Owin;
using Microsoft.Owin;
using System.Web.Http;
using Microsoft.Owin.Cors;
using GastosBack_ConsoleApp.Resolver;
using System.Net.Http.Headers;
using Swashbuckle.Application;

namespace GastosBack_ConsoleApp
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {

            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Swashbuckle
            config
                .EnableSwagger(c => c.SingleApiVersion("v1", "Gastos API"))
                .EnableSwaggerUi();

            //Errors
            //GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            //Unity
            var container = new UnityContainer();
            container.RegisterType<IRubroBancoRepo, RubroBancoRepo>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            //Json
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            //Cors
            appBuilder.UseCors(CorsOptions.AllowAll);

            //WebApi
            appBuilder.UseWebApi(config);

            //SignalR
            appBuilder.MapSignalR();
        }
    }
}