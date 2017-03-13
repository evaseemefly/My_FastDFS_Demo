using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace FastDFS.Client.Config
{
    [Serializable]
    public class FastDfsConfig
    {
        public FastDfsConfig()
        {
            FastDfsServer = new List<FastDfsServer>();
        }

        /// <summary>
        /// fdfs 群组名称
        /// </summary>
        [XmlAttribute]
        public string GroupName { get; set; }

        /// <summary>
        /// fdfs服务集合
        /// </summary>
        [XmlElement]
        public List<FastDfsServer> FastDfsServer { get; set; }

        
    }
}
