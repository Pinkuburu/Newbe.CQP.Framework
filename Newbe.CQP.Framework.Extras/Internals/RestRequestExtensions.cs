using System.Linq;
using RestSharp;

namespace Newbe.CQP.Framework.Extensions.Internals
{
    internal static class RestRequestExtensions
    {
        public static void SetCoolCookies(this IRestRequest restRequest, ICoolQApi api)
        {
            var cookies = api.GetCookies();
            foreach (var s in cookies.Split(';').Select(x => x.Trim()))
            {
                var nameValue = s.Split('=');
                restRequest.AddCookie(nameValue[0], nameValue[1]);
            }
        }

        public static void SetReferer(this IRestRequest restRequest, string referer)
        {
            restRequest.AddHeader("Referer", referer);
        }

        public static void SetAccept(this IRestRequest restRequest,
            string accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8")
        {
            restRequest.AddHeader("Accept", accept);
        }

        public static void SetUserAgent(this IRestRequest restRequest,
            string userAgent =
                "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)")
        {
            restRequest.AddHeader("User-Agent", userAgent);
        }
    }
}