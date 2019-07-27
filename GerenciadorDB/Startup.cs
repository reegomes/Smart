using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GerenciadorDB.Startup))]
namespace GerenciadorDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
