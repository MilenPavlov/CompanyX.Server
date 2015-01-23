using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CompanyX.API.OwinData;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
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