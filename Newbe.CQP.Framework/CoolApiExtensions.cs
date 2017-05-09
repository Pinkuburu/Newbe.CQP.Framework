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
    }
}