using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITLA_Jobs.Startup))]
namespace ITLA_Jobs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
