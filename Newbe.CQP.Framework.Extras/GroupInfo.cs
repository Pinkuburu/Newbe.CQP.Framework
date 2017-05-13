using Newtonsoft.Json;

namespace Newbe.CQP.Framework.Extensions
{
    /// <summary>
    /// Ⱥ������Ϣ
    /// </summary>
    public class GroupInfo
    {
        /// <summary>
        /// Ⱥ��
        /// </summary>
        [JsonProperty("gc")]
        public long GroupNumber { get; set; }

        /// <summary>
        /// Ⱥ����
        /// </summary>
        [JsonProperty("gn")]
        public string GroupName { get; set; }

        /// <summary>
        /// Ⱥ��QQ
        /// </summary>
        [JsonProperty("owner")]
        public long OwnerNumber { get; set; }
    }
}