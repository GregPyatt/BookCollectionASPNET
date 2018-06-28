using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookCollectionASPNET.Startup))]
namespace BookCollectionASPNET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
