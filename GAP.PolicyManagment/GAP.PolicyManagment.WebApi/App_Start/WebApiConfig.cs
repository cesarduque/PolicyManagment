using GAP.PolicyManagment.Core;
using GAP.PolicyManagment.Core.Repositories;
using GAP.PolicyManagment.Core.Services.Implementation;
using GAP.PolicyManagment.Core.Services.Interface;
using GAP.PolicyManagment.Infrastructure;
using GAP.PolicyManagment.Infrastructure.Repositories;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace GAP.PolicyManagment.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //Unity Configuration
            var container = new UnityContainer();
            using (var hierarchicalLifetimeManager = new HierarchicalLifetimeManager())
            {
                container.RegisterType<IClientRepository, ClientRepository>(hierarchicalLifetimeManager);
            }

            using (var hierarchicalLifetimeManager = new HierarchicalLifetimeManager())
            {
                container.RegisterType<ICoverageTypeRepository, CoverageTypeRepository>(hierarchicalLifetimeManager);
            }

            using (var hierarchicalLifetimeManager = new HierarchicalLifetimeManager())
            {
                container.RegisterType<IPolicyCoverageTypeRepository, PolicyCoverageTypeRepository>(hierarchicalLifetimeManager);
            }

            using (var hierarchicalLifetimeManager = new HierarchicalLifetimeManager())
            {
                container.RegisterType<IPolicyRepository, PolicyRepository>(hierarchicalLifetimeManager);
            }

            using (var hierarchicalLifetimeManager = new HierarchicalLifetimeManager())
            {
                container.RegisterType<IRiskTypeRepository, RiskTypeRepository>(hierarchicalLifetimeManager);
            }

            using (var hierarchicalLifetimeManager = new HierarchicalLifetimeManager())
            {
                container.RegisterType<IClientService, ClientService>(hierarchicalLifetimeManager);
            }

            using (var hierarchicalLifetimeManager = new HierarchicalLifetimeManager())
            {
                container.RegisterType<ICoverageTypeService, CoverageTypeService>(hierarchicalLifetimeManager);
            }

            using (var hierarchicalLifetimeManager = new HierarchicalLifetimeManager())
            {
                container.RegisterType<IPolicyService, PolicyService>(hierarchicalLifetimeManager);
            }

            using (var hierarchicalLifetimeManager = new HierarchicalLifetimeManager())
            {
                container.RegisterType<IRiskTypeService, RiskTypeService>(hierarchicalLifetimeManager);
            }

            using (var hierarchicalLifetimeManager = new HierarchicalLifetimeManager())
            {
                container.RegisterType<IUnitOfWork, UnitOfWork>(hierarchicalLifetimeManager);
            }

            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver
               = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();

            config.Formatters.JsonFormatter.SerializerSettings.Formatting
                = Newtonsoft.Json.Formatting.Indented;
        }
    }
}
