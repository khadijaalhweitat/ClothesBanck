using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BanckOfClothesServer.Startup))]
namespace BanckOfClothesServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
