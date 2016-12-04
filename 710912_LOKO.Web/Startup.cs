using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_710912_LOKO.Web.Startup))]
namespace _710912_LOKO.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
