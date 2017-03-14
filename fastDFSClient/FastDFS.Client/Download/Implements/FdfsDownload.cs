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
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public FileDownloadResult GetTargetFile(FileDownParameter param)
        {
            byte[] content=null;
            string errorMsg = string.Empty;
            try
            {
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
