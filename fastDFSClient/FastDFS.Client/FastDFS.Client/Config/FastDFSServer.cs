using System;
using System.Xml.Serialization;

namespace FastDFS.Client.Config
{
    [Serializable]
    public class FastDfsServer
    {
        [XmlAttribute]
        public string IpAddress { get; set; }

        [XmlAttribute]
        public int Port { get; set; }

        #region 以下内容为我自己添加的内容


        /// <summary>
        /// 失败次数
        /// </summary>
        [XmlAttribute]
        public int FailCount { get; set; }

        /// <summary>
        /// 失败阈值
        /// </summary>
        [XmlAttribute]
        public int MaxFailCount { get; set; }
        #endregion
    }
}