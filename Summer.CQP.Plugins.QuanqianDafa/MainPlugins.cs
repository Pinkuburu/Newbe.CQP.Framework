using Newbe.CQP.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summer.CQP.Plugins.QuanqianDafa
{
    public class MainPlugins : PluginBase
    {
        public MainPlugins(ICoolQApi coolQApi) : base(coolQApi)
        {
        }

        public override string AppId => "Summer.CQP.Plugins.QuanqianDafa";

        public override int ProcessGroupMemberIncrease(int subType, int sendTime, long fromGroup, long fromQq,
            long target)
        {
            CoolQApi.SendGroupMsg(fromGroup,
                $"{CoolQCode.At(fromQq)}\r\n新人捐赠时间,一分也是情，一分也是爱\r\nhttp://git.oschina.net/yks/Newbe.CQP.Framework\r\n{CoolQCode.Image("image.jpg")}");
            return base.ProcessGroupMemberIncrease(subType, sendTime, fromGroup, fromQq, target);
        }
    }
}