using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Day1_Money.Startup))]
namespace MVC_Day1_Money
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
