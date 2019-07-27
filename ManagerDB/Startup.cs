using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManagerDB.Startup))]
namespace ManagerDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
