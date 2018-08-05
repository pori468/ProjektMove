using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjektMove.Startup))]
namespace ProjektMove
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
