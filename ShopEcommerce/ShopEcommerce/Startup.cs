using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopEcommerce.Startup))]
namespace ShopEcommerce
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
