using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProektnaZadaca.Startup))]
namespace ProektnaZadaca
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
