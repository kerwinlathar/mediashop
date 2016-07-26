using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MediaShopASP.Startup))]
namespace MediaShopASP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
