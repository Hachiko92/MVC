using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Proyecto04_Proyectos.Startup))]
namespace Proyecto04_Proyectos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
