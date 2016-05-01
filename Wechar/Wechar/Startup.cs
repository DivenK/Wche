using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wechar.Startup))]
namespace Wechar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
