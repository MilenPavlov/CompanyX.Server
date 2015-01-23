using CompanyX.Data.Context;
using CompanyX.Data.Interfaces;
using CompanyX.Data.Repositories;
using CompanyX.Data.Services;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace CompanyX.API
{
    public partial class Startup
    {
        public void ConfigureDi(HttpConfiguration config)
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            var resolver = new UnityDependencyResolver(container);
            config.DependencyResolver = resolver;
            container.RegisterType<IEntityFactory, EntityFactory>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            //container.RegisterType<IDbContext, CompanyContext>( new ContainerControlledLifetimeManager());
        }
    }
}