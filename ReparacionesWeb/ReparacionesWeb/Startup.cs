using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReparacionesWeb.Startup))]
namespace ReparacionesWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

    }
}
