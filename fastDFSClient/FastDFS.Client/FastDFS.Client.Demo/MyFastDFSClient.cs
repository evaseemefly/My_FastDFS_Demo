using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastDFS.Client;
using System.Net;
using FastDFS.Client.Common;
using Common.Config.Fdfs;
using System.Configuration;
using FastDFS.Client.Config;

namespace FastDFS.Client.Demo
{
    class MyFastDFSClient:FastDFSClient
    {
        /// <summary>
        /// fastDFS服务器地址列表
        /// </summary>
        static List<IPEndPoint> trackerIPs = new List<IPEndPoint>();
        
        /// <summary>
        /// FastDFS文件组
        /// </summary>
        public static StorageNode DefaultGroup;
        /// <summary>
        /// 注意静态构造函数不允许有访问修饰符
        /// 默认都是Public的？
        /// 
        /// </summary>
        static MyFastDFSClient()
        {
            List<IPEndPoint> trackerIPs = new List<IPEndPoint>();
            //从配置文件中读取Common/Config/Fdfs/TrackerSection相关对象中对应的配置
            #region 从配置文件中读取Common/Config/Fdfs/TrackerSection相关对象中对应的配置
            //TrackerSection trackersSection = ConfigurationManager.GetSection("TrackerSection") as TrackerSection;            
            //foreach (MyTracker item in trackersSection.Trackers)
            //{
            //    trackerIPs.Add(new IPEndPoint(IPAddress.Parse(item.Host), item.Port));
            //}
            #endregion

            /*
                读取fastdfs配置节下的配置文件
                以FastDFS.Client.Config 中FastDFSConfig 对象的方式读取出来
            */
            var config = FastDfsManager.GetConfigSection();
            try
            {
                //根据指定群组名称获取存储节点
                DefaultGroup = GetStorageNode(config.GroupName);
                foreach (var item in config.FastDfsServer)
                {
                    trackerIPs.Add(new IPEndPoint(IPAddress.Parse(item.IpAddress), item.Port));
                }
                //初始化
                ConnectionManager.Initialize(trackerIPs);
            }
            catch (Exception ex)
            {
                //Logger.LoggerFactory.Instance.Logger_Error(ex);
            }
        }



       public static void Test()
        {

        }
    }
}
