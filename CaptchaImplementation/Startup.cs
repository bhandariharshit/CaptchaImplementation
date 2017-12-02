using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CaptchaImplementation.Startup))]
namespace CaptchaImplementation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
