using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastDFS.Client;
using FastDFS.Client.Common;
using Model.FdfsParameters;
using Model.Result;

namespace Download.Implements
{
    public class FdfsDownload:BaseFdfs.BaseFdfs,IDownload
    {
       

        public FdfsDownload()
        {
            base.InitStorageNode();
        }


        /// <summary>
        /// 下载指定名称的文件
        /// eg：FileName：M00/00/00/wKgAcVjI-NeAa0HyAAInn_BrY3k084.jpg
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public FileDownloadResult GetTargetFile(FileDownParameter param)
        {
            byte[] content=null;
            string errorMsg = string.Empty;
            try
            {
                //其中的base.Node为：

                /*
                 * eg:
                 * EndPoint: 192.168.0.113:23000
                 * GroupName:group1
                 * StorePathIndex:0
                 */
                content = FastDFSClient.DownloadFile(base.Node, param.FileName);
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
            }
            
           return new FileDownloadResult()
           {
               Content = content,
                ErrorMessage= errorMsg
           } ;
        } 
        
    }
}
