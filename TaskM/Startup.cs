using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaskM.Startup))]
namespace TaskM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
