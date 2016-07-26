using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MediaShopAspUiCustomers.Startup))]
namespace MediaShopAspUiCustomers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
