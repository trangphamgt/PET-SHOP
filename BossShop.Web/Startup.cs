using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BossShop.Web.Startup))]
namespace BossShop.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
