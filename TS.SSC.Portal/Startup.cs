using Microsoft.Owin;
using Owin;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(TS.SSC.Portal.Startup))]
namespace TS.SSC.Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            ConfigureAuth(app);
        }
    }
}
