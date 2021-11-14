using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zoohackathon2021.Startup))]
namespace Zoohackathon2021
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
