using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SOCProject1.Startup))]
namespace SOCProject1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
