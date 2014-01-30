using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Saleular.Startup))]
namespace Saleular
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
