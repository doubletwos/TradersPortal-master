using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TradersPortal.Startup))]
namespace TradersPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
