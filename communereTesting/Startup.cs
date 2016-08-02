using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(communereTesting.Startup))]
namespace communereTesting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
