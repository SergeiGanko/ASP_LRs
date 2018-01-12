using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_60321_Ganko.Startup))]
namespace _60321_Ganko
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
