using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SsaPredavanje.Startup))]
namespace SsaPredavanje
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
