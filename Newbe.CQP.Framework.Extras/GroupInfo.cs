using Newtonsoft.Json;

namespace Newbe.CQP.Framework.Extensions
{
    /// <summary>
    /// 群基本信息
    /// </summary>
    public class GroupInfo
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("gc")]
        public long GroupNumber { get; set; }

        /// <summary>
        /// 群名称
        /// </summary>
        [JsonProperty("gn")]
        public string GroupName { get; set; }

        /// <summary>
        /// 群主QQ
        /// </summary>
        [JsonProperty("owner")]
        public long OwnerNumber { get; set; }
    }
}