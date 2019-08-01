using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VehicleApplication.Startup))]
namespace VehicleApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
