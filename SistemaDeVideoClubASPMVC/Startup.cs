using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaDeVideoClubASPMVC.Startup))]
namespace SistemaDeVideoClubASPMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
