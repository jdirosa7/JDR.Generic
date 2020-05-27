using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JDR.Generic.UI.Web.Startup))]
namespace JDR.Generic.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
