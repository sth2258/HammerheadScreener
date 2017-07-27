using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TravelPlanner.Startup))]
namespace TravelPlanner
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
