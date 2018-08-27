using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LocalBeerRaterApp.WebMVC.Startup))]
namespace LocalBeerRaterApp.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
