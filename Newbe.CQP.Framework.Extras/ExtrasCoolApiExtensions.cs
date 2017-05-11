using System;
using System.Collections.Generic;
using System.Linq;
using Newbe.CQP.Framework.Extensions.Internals;
using Newtonsoft.Json;
using RestSharp;

namespace Newbe.CQP.Framework.Extensions
{
    /// <summary>
    /// 对ICoolApi的额外扩展
    /// </summary>
    public static class ExtrasCoolApiExtensions
    {
        /// <summary>
        /// 获取群列表
        /// </summary>
        /// <param name="api"></param>
        /// <returns></returns>
        public static IEnumerable<GroupInfo> GetGroupList(this ICoolQApi api)
        {
            try
            {
                var client = new RestClient("http://qun.qq.com/cgi-bin/qun_mgr/get_group_list");
                var restRequest = new RestRequest();
                restRequest.AddParameter("bkn", api.GetCsrfToken().ToString(), ParameterType.GetOrPost);
                restRequest.SetAccept();
                restRequest.SetUserAgent();
                restRequest.SetReferer("http://qun.qq.com/member.html");
                restRequest.SetCoolCookies(api);
                var restResponse = client.Post(restRequest);
                var re = JsonConvert.DeserializeObject<GetGroupListResult>(restResponse.Content).GroupInfos;
                return re;
            }
            catch (Exception e)
            {
                api.AddLog(CoolQLogLevel.Fatal, $"获取群列表发生异常:{e.Message}");
                return Enumerable.Empty<GroupInfo>();
            }
        }
    }
}