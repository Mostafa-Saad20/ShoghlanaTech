using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShoghlanaTech.Startup))]
namespace ShoghlanaTech
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
