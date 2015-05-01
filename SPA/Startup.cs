using Microsoft.Owin;
using Owin;
using SPA;

[assembly: OwinStartup(typeof(Startup))]

namespace SPA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
