using Nancy;

namespace Newbe.CQP.Framework.Docs
{
    public class MainModule : NancyModule
    {
        public MainModule()
        {
            Get[@"/"] = parameters => { return Response.AsFile("Content/index.html", "text/html"); };
        }
    }
}