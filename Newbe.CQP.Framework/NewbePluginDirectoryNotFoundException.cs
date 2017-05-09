using System;

namespace Newbe.CQP.Framework
{
    /// <summary>
    /// 插件目录不存在异常
    /// </summary>
    public class NewbePluginDirectoryNotFoundException : Exception
    {
        /// <summary>
        /// 插件名称
        /// </summary>
        public string PluginName { get; }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="pluginName"></param>
        public NewbePluginDirectoryNotFoundException(string pluginName)
        {
            PluginName = pluginName;
        }
        /// <summary>
        /// 错误信息
        /// </summary>
        public override string Message => $"无法找到插件{PluginName}对应的dll目录";
    }
}