using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PS.HireRocks.Web.Startup))]
namespace PS.HireRocks.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
