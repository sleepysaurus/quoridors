using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Quoridors.Startup))]
namespace Quoridors
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
