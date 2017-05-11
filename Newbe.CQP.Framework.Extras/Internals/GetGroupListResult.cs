using Newtonsoft.Json;

namespace Newbe.CQP.Framework.Extensions.Internals
{
    internal class GetGroupListResult
    {
        public int ec { get; set; }

        [JsonProperty("join")]
        public GroupInfo[] GroupInfos { get; set; }
    }
}