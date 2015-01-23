using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CompanyX.API.Startup))]
namespace CompanyX.API
{
    public partial class Startup
    {       
        public void Configuration(IAppBuilder app)
        {
            
            var config = new HttpConfiguration();
            ConfigureAuth(app);
            WebApiConfig.Register(config);
            app.UseWebApi(config);

            ConfigureDi(config);
        }       


    }
}