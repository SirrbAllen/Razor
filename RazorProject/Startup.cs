using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RazorProject.Startup))]
namespace RazorProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
