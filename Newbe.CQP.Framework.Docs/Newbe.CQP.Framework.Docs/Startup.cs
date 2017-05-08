using Owin;

namespace Newbe.CQP.Framework.Docs
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
#if DEBUG
            app.UseErrorPage();
#endif
            app.UseNancy();
        }
    }
}