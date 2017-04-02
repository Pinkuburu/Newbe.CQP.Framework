﻿namespace Newbe.CQP.Framework
{
    public abstract class PluginBase
    {
        /// <summary>
        /// AppID
        /// </summary>
        public abstract string AppId { get; }

        /// <summary>
        /// Api版本号，若酷Q官方SDK没有更新此版本号，请勿改动此值
        /// </summary>
        public string ApiVersion { get; } = "9";

        /// <summary>
        /// 此函数会在插件被开启时发生。
        /// </summary>
        /// <returns> 返回处理过程是否成功的值。</returns>
        public abstract int Enabled();

        /// <summary>
        /// 此函数会在插件被禁用时发生。
        /// </summary>
        /// <returns> 返回处理过程是否成功的值。</returns>
        public abstract int Disabled();

        /// <summary>
        /// 向酷Q提供插件信息。
        /// </summary>
        /// <returns>一个固定格式字符串。</returns>
        public string AppInfo()
        {
            return (ApiVersion + "," + AppId).ToLower();
        }

        /// <summary>
        /// 获取此插件的AuthCode。
        /// </summary>
        /// <param name="authcode">由酷Q提供的AuthCode。</param>
        /// <returns> </returns>
        public int Initialize(int authcode)
        {
            //请勿更改此函数
            PluginHelper.CQ.SetAuthCode(authcode);
            return 0;
            //固定返回0
        }

        /// <summary>
        /// 此函数会在酷Q退出时被调用。
        /// </summary>
        /// <returns> </returns>
        public int CoolQExited()
        {
            return 0;
        }


        /// <summary>
        /// 处理私聊消息。
        /// </summary>
        /// <param name="subType">私聊消息类型。11代表消息来自好友；1代表消息来自在线状态；2代表消息来自群；3代表消息来自讨论组。</param>
        /// <param name="sendTime">消息发送时间的时间戳。</param>
        /// <param name="fromQQ">发送此消息的QQ号码。</param>
        /// <param name="msg">消息的内容。</param>
        /// <param name="font">消息所使用的字体。</param>
        /// <returns> 是否拦截消息的值，0为忽略消息，1为拦截消息。</returns>
        public abstract int ProcessPrivateMessage(int subType, int sendTime, long fromQQ, string msg, int font);


        /// <summary>
        /// 处理群聊消息。
        /// </summary>
        /// <param name="subType">消息类型，目前固定为1。</param>
        /// <param name="sendTime">消息发送时间的时间戳。</param>
        /// <param name="fromGroup">消息来源群号。</param>
        /// <param name="fromQQ">发送此消息的QQ号码。</param>
        /// <param name="fromAnonymous">发送此消息的匿名用户。</param>
        /// <param name="msg">消息内容。</param>
        /// <param name="font">消息所使用字体。</param>
        /// <returns> 是否拦截消息的值，0为忽略消息，1为拦截消息。</returns>
        public abstract int ProcessGroupMessage(int subType, int sendTime, long fromGroup, long fromQQ,
            string fromAnonymous,
            string msg, int font);

        /// <summary>
        /// 处理讨论组消息。
        /// </summary>
        /// <param name="subType">消息类型，目前固定为1。</param>
        /// <param name="sendTime">消息发送时间的时间戳。</param>
        /// <param name="fromDiscuss">消息来源讨论组号。</param>
        /// <param name="fromQQ">发送此消息的QQ号码。</param>
        /// <param name="msg">消息内容。</param>
        /// <param name="font">消息所使用字体。</param>
        /// <returns> 是否拦截消息的值，0为忽略消息，1为拦截消息。</returns>
        public abstract int ProcessDiscussGroupMessage(int subType, int sendTime, long fromDiscuss, long fromQQ,
            string msg,
            int font);

        /// <summary>
        /// 处理群文件上传事件。
        /// </summary>
        /// <param name="subType">消息类型，目前固定为1。</param>
        /// <param name="sendTime">事件发生时间的时间戳。</param>
        /// <param name="fromGroup">事件来源群号。</param>
        /// <param name="fromQQ">上传此文件的QQ号码。</param>
        /// <param name="file">上传的文件的信息。</param>
        /// <returns> 是否拦截消息的值，0为忽略消息，1为拦截消息。</returns>
        public abstract int ProcessGroupUpload(int subType, int sendTime, long fromGroup, long fromQQ, string file);

        /// <summary>
        /// 处理群管理员变动事件。
        /// </summary>
        /// <param name="subType">事件类型。1为被取消管理员，2为被设置管理员。</param>
        /// <param name="sendTime">事件发生时间的时间戳。</param>
        /// <param name="fromGroup">事件来源群号。</param>
        /// <param name="target">被操作的QQ。</param>
        /// <returns> 是否拦截消息的值，0为忽略消息，1为拦截消息。</returns>
        public abstract int ProcessGroupAdminChange(int subType, int sendTime, long fromGroup, long target);

        /// <summary>
        /// 处理群成员数量减少事件。
        /// </summary>
        /// <param name="subType">事件类型。1为群员离开；2为群员被踢为；3为自己(即登录号)被踢。</param>
        /// <param name="sendTime">事件发生时间的时间戳。</param>
        /// <param name="fromGroup">事件来源群号。</param>
        /// <param name="fromQQ">事件来源QQ。</param>
        /// <param name="target">被操作的QQ。</param>
        /// <returns> 是否拦截消息的值，0为忽略消息，1为拦截消息。</returns>
        public abstract int ProcessGroupMemberDecrease(int subType, int sendTime, long fromGroup, long fromQQ,
            long target);

        /// <summary>
        /// 处理群成员添加事件。
        /// </summary>
        /// <param name="subType">事件类型。1为管理员已同意；2为管理员邀请。</param>
        /// <param name="sendTime">事件发生时间的时间戳。</param>
        /// <param name="fromGroup">事件来源群号。</param>
        /// <param name="fromQQ">事件来源QQ。</param>
        /// <param name="target">被操作的QQ。</param>
        /// <returns> 是否拦截消息的值，0为忽略消息，1为拦截消息。</returns>
        public abstract int ProcessGroupMemberIncrease(int subType, int sendTime, long fromGroup, long fromQQ,
            long target);

        /// <summary>
        /// 处理好友已添加事件。
        /// </summary>
        /// <param name="subType">事件类型。固定为1。</param>
        /// <param name="sendTime">事件发生时间的时间戳。</param>
        /// <param name="fromQQ">事件来源QQ。</param>
        /// <returns> 是否拦截消息的值，0为忽略消息，1为拦截消息。</returns>
        public abstract int ProcessFriendsAdded(int subType, int sendTime, long fromQQ);

        /// <summary>
        /// 处理好友添加请求。
        /// </summary>
        /// <param name="subType">事件类型。固定为1。</param>
        /// <param name="sendTime">事件发生时间的时间戳。</param>
        /// <param name="fromQQ">事件来源QQ。</param>
        /// <param name="msg">附言内容。</param>
        /// <param name="font">消息所使用字体。</param>
        /// <returns> 是否拦截消息的值，0为忽略消息，1为拦截消息。</returns>
        public abstract int ProcessAddFriendRequest(int subType, int sendTime, long fromQQ, string msg, int font);

        /// <summary>
        /// 处理加群请求。
        /// </summary>
        /// <param name="subType">请求类型。1为他人申请入群；2为自己(即登录号)受邀入群。</param>
        /// <param name="sendTime">请求发送时间戳。</param>
        /// <param name="fromGroup">要加入的群的群号。</param>
        /// <param name="fromQQ">发送此请求的QQ号码。</param>
        /// <param name="msg">附言内容。</param>
        /// <param name="responseMark">用于处理请求的标识。</param>
        /// <returns> 是否拦截消息的值，0为忽略消息，1为拦截消息。</returns>
        public abstract int ProcessJoinGroupRequest(int subType, int sendTime, long fromGroup, long fromQQ, string msg,
            string responseMark);
    }
}