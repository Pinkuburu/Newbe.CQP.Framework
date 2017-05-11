using System;
using System.Collections.Generic;
using System.Linq;

namespace Newbe.CQP.Framework
{
    /// <summary>
    /// 对ICoolApi的额外扩展
    /// </summary>
    public static class CoolApiExtensions
    {
        /// <summary>
        ///     添加运行日志
        /// </summary>
        /// <param name="api"></param>
        /// <param name="logType">日志类型</param>
        /// <param name="content">日志内容</param>
        /// <returns></returns>
        public static int AddLog(this ICoolQApi api, CoolQLogLevel logType, string content)
        {
            return api.AddLog((int) logType, logType, content);
        }

        /// <summary>
        /// 转换_ansihex到群成员信息
        /// </summary>
        /// <param name="source">源字节集</param>
        /// <param name="gm">群成员</param>
        /// <returns></returns>
        private static bool ConvertAnsiHexToGroupMemberInfo(byte[] source, ref GroupMemberInfo gm)
        {
            if (source == null || source.Length < 40)
                return false;
            var u = new Unpack(source);
            gm.GroupId = (long) u.GetLong();
            gm.Number = (long) u.GetLong();
            gm.NickName = u.GetLenStr();
            gm.InGroupName = u.GetLenStr();
            gm.Gender = (int) u.GetInt() == 0 ? "男" : " 女";
            gm.Age = (int) u.GetInt();
            gm.Area = u.GetLenStr();
            gm.JoinTime = new DateTime(1970, 1, 1, 0, 0, 0).ToLocalTime()
                .AddSeconds((int) u.GetInt());
            gm.LastSpeakingTime = new DateTime(1970, 1, 1, 0, 0, 0).ToLocalTime()
                .AddSeconds((int) u.GetInt());
            gm.Level = u.GetLenStr();
            var manager = (int) u.GetInt();
            gm.Authority = manager == 3 ? "群主" : (manager == 2 ? "管理员" : "成员");
            gm.HasBadRecord = (u.GetInt() == 1);
            gm.Title = u.GetLenStr();
            gm.TitleExpirationTime = (int) u.GetInt();
            gm.CanModifyInGroupName = (u.GetInt() == 1);
            return true;
        }

        /// <summary>
        /// 转换_文本到群成员列表信息
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="lsGm">群成员列表</param>
        /// <returns></returns>
        private static bool ConvertStrToGroupMemberInfos(string source, ref List<GroupMemberInfo> lsGm)
        {
            if (source == string.Empty)
                return false;
            var data = source.DeBase64();
            if (data == null || data.Length < 10)
                return false;
            var u = new Unpack(data);
            var count = u.GetInt();
            for (int i = 0; i < count; i++)
            {
                if (u.Len() <= 0)
                    return false;
                var gm = new GroupMemberInfo();
                if (!ConvertAnsiHexToGroupMemberInfo(u.GetToken(), ref gm))
                    return false;
                lsGm.Add(gm);
            }
            return true;
        }

        /// <summary>
        ///     取群成员信息(支持缓存)
        /// </summary>
        /// <param name="api">api</param>
        /// <param name="groupId">目标群</param>
        /// <param name="qqId">目标QQ</param>
        /// <param name="cache">是否缓存</param>
        /// <returns></returns>
        public static ModelWithSourceString<GroupMemberInfo> GetGroupMemberInfoV2(this ICoolQApi api,
            long groupId, long qqId,
            bool cache)
        {
            var data = api.GetGroupMemberInfoV2AsString(groupId, qqId, cache);
            var source = Convert.FromBase64String(data);
            var re = new ModelWithSourceString<GroupMemberInfo>
            {
                SourceString = data
            };
            GroupMemberInfo gm = new GroupMemberInfo();
            if (ConvertAnsiHexToGroupMemberInfo(source, ref gm))
            {
                re.Model = gm;
            }
            return re;
        }

        /// <summary>
        /// 取群成员列表
        /// </summary>
        /// <param name="api">api</param>
        /// <param name="groupId">目标群</param>
        /// <returns></returns>
        public static ModelWithSourceString<IEnumerable<GroupMemberInfo>> GetGroupMemberList(this ICoolQApi api,
            long groupId)
        {
            var source = api.GetGroupMemberListAsString(groupId);
            var list = new List<GroupMemberInfo>();
            var re = new ModelWithSourceString<IEnumerable<GroupMemberInfo>>
            {
                SourceString = source,
                Model = Enumerable.Empty<GroupMemberInfo>()
            };
            if (ConvertStrToGroupMemberInfos(source, ref list))
            {
                re.Model = list;
            }
            return re;
        }
    }
}