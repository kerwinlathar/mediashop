using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MediaShopCustomerUI.Startup))]
namespace MediaShopCustomerUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
