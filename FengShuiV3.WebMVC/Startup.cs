using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FengShuiV3.WebMVC.Startup))]
namespace FengShuiV3.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
