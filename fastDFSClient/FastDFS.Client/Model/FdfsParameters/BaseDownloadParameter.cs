﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastDFS.Client;
using FastDFS.Client.Common;

namespace Model.FdfsParameters
{
    /// <summary>
    /// 下载父类参数
    /// </summary>
    public class BaseDownloadParameter
    {
        public StorageNode Node{get;set;}

        public string FileName { get; set; }
    }
}
