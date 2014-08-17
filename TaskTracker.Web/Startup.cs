using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaskTracker.Web.Startup))]
namespace TaskTracker.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
