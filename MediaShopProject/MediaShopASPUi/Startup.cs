using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MediaShopASPUi.Startup))]
namespace MediaShopASPUi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
