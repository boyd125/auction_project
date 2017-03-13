using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(auction_proj.Startup))]
namespace auction_proj
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
