using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bredvid.Blog.KuduDeploy.Web.Startup))]
namespace Bredvid.Blog.KuduDeploy.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
